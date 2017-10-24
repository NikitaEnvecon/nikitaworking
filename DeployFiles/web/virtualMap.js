var itemShapeLayer = null;
var pinLayer = null;
var routeArrowLayer = null;
var routeRoadLayer = null;
var routes = [];
var earthRadius=6367;
var arrowRouteList = null;

defaultStartLatitude = null;
defaultStartLongitude = null;
defaultStartZoomLevel = null;

window.onresize = WindowResize;

translatedHours = null;
translatedMinutes = null;
translatedSeconds = null;
translatedOneDistance = null;
translatedDistanceUnit = null;

var routeStartIcon = "startFlag.gif";
var routeEndIcon = "endFlag.gif";

globalDistanceUnit = null;

//104570, start
var translatedKeyErrorTxt;
function InitializeMapClient(key, startingLongitude, startingLatitude, startingZoomLevel, displayScaleBar, distanceUnit, transHours, transMinutes, transSeconds, transOneDistance, transDistUnit, keyerror) {
    translatedHours = transHours;
    translatedMinutes = transMinutes;
    translatedSeconds = transSeconds;
    translatedOneDistance = transOneDistance;
    translatedDistanceUnit = transDistUnit;
    globalDistanceUnit = distanceUnit;
    translatedKeyErrorTxt = keyerror;

    //BugId 96988, start
    map = new VEMap('virtualMap');
    map.AttachEvent("oncredentialsvalid", MyHandleKeyValid);
    map.AttachEvent("oncredentialserror", MyHandleKeyError);
    map.SetCredentials(key);
    //BugId 96988, end
    
    defaultStartLatitude = startingLatitude;
    defaultStartLongitude = startingLongitude;
    defaultStartZoomLevel = startingZoomLevel;
    
    // Set the correct translation of the context menu
    var startingPoint = new VELatLong(startingLatitude, startingLongitude);
    var mapOptions = new VEMapOptions();
    mapOptions.EnableBirdseye = false;
    map.LoadMap(startingPoint, startingZoomLevel, null, null, null, false, null, mapOptions);
    
    itemShapeLayer = new VEShapeLayer();
    map.AddShapeLayer(itemShapeLayer);
    pinLayer = new VEShapeLayer()
    map.AddShapeLayer(pinLayer);
    routeArrowLayer = new VEShapeLayer()
    map.AddShapeLayer(routeArrowLayer);
    routeRoadLayer = new VEShapeLayer()
    map.AddShapeLayer(routeRoadLayer);
    
    var options =  new VEClusteringOptions(); 
    options.Callback = clusteringCallback; 
    itemShapeLayer.SetClusteringConfiguration(VEClusteringType.Grid, options);
    
    document.getElementById('MSVE_obliqueNotification').innerHTML = "";
    
    if(displayScaleBar == "True") {
        switch(distanceUnit) {
            case this.scaleBarDistanceUnit.Kilometers:
                map.SetScaleBarDistanceUnit(VEDistanceUnit.Kilometers);
                break;
            case this.scaleBarDistanceUnit.Miles:
                map.SetScaleBarDistanceUnit(VEDistanceUnit.Miles);            
                break;
        }
    }

    else {
        map.HideScalebar();
    }
       
    map.AttachEvent("onclick", OnClick);
    map.AttachEvent("onmouseover", OnMouseOver);
    map.AttachEvent("onmouseout", OnMouseOut);
    map.AttachEvent("onendzoom",EndZoomHandler);
    WindowResize();
    window.external.InitializeMapClientFinished();
}
//104570, end

function UpdateMapSettings(displayScaleBar, distanceUnit) {
    if(displayScaleBar == "True") {
        switch(distanceUnit) {
            case this.scaleBarDistanceUnit.Kilometers:
                map.SetScaleBarDistanceUnit(VEDistanceUnit.Kilometers);
                break;
            case this.scaleBarDistanceUnit.Miles:
                map.SetScaleBarDistanceUnit(VEDistanceUnit.Miles);            
                break;
        }
        map.ShowScalebar();
    }
    else {
        map.HideScalebar();
    }
}


function clusteringCallback(clusters) 
{ 
    for (var i=0; i < clusters.length; i++) 
    { 
        var cluster = clusters[i]; 
        var clusterShape = cluster.GetClusterShape(); 
        clusterShape.cluster = cluster;
        
        // Set alert icon if needed
        for (var j=0; j < cluster.Shapes.length; j++) { 
            var shape = cluster.Shapes[j];
            if(shape.alertTriggered) {
                clusterShape.SetCustomIcon("<img src='_122_1_Alarm.gif' />");
                j = cluster.Shapes.length;
            }
        }        
   } 
}

function ClusterClicked(clusterShape, mouseArgs) {       
        var cluster = clusterShape.cluster;
        var title = window.external.GetClusterHeading();
        var number = cluster.Shapes.length + '';
        title = title.replace('{0}', number);
        clusterShape.SetTitle(title);
        
        var clusterDescription = "<div>";
        for (var j=0; j < cluster.Shapes.length; j++) { 
            var shape = cluster.Shapes[j];
            var keyRefArray = shape.keyRef.split('^');
            var keyRefRepresentation = "";
            for(var i = 0; i < keyRefArray.length; i++) {
                if(keyRefArray[i].indexOf("=") != -1) {
                    var nameAndValue = keyRefArray[i].split('=');
                    if(i != 0) { 
                        keyRefRepresentation = keyRefRepresentation + ", ";
                    }
                    keyRefRepresentation = keyRefRepresentation + nameAndValue[1];
                }
            }
            clusterDescription += "<a href='#' onclick=\"window.external.ObjectClicked('" + shape.luName + "', '" + shape.keyRef + "');\">" + shape.luName + ": " + keyRefRepresentation + "</a><br/>" ;           
        }
        clusterDescription += "</div>";
        clusterShape.SetDescription(clusterDescription);
        
        map.ShowInfoBox(clusterShape);
}

//BugId 96988, start
function MyHandleKeyValid() {
}

//104570, start
function MyHandleKeyError() {
    alert(translatedKeyErrorTxt);
}
//104570, end
//BugId 96988, end

function EndZoomHandler(e) {
    var center = map.GetCenter();
    map.SetCenter(center);
    updateImageOffset();
    ReDrawRoutes();
}

function GoToSettingsClient() {
    window.external.GoToUserSettingsServer();
}

function DisplayUserSettingsClient() {
    window.external.DisplayUserSettingsServer();
}

function SearchClient(identifier) {
    hidePopupMenu();
    window.external.SearchServer(identifier);
}

function UpdateItemsClient(listOfItems, xOffset, yOffset) {
    
    if(listOfItems.indexOf("&:") !=  -1) {       
        var items = listOfItems.split("&:");
        var addedLocations = [];
       
        // Draw positions
        var locationsForSameObject = [];
        var lastLuName = null;
        var lastKeyRef = null;
        for(i=0; i<items.length-1; i++) {
            var startItemString = items[i].split("&;");
            var startPosition = new VELatLong(parseFloat(startItemString[0]), parseFloat(startItemString[1]));
            var startLuName = startItemString[2];
            var startKeyRef = startItemString[3];
            var startIconHtml = startItemString[4];
            var startAlertTriggered = false;
            if(startItemString[5] == "True") 
                startAlertTriggered = true;
            var startIndex = i;
            
            var j = i;
            var abortLoop = false
            while(j<items.length-1 && !abortLoop) {
                var currentItemString = items[j].split("&;");
                var currentPosition = new VELatLong(parseFloat(currentItemString[0]), parseFloat(currentItemString[1]));
                var currentLuName = currentItemString[2];
                var currentKeyRef = currentItemString[3];
                addedLocations.push(currentPosition);
                if(startLuName == currentLuName && startKeyRef == currentKeyRef) {
                    locationsForSameObject.push(currentPosition);
                    j++;
                }
                else {
                    abortLoop = true;
                    AddItemClient(locationsForSameObject, startLuName, startKeyRef, startIconHtml, xOffset, yOffset, startAlertTriggered);
                    locationsForSameObject = [];
                }
                
            }
            
            if(locationsForSameObject.length != 0)
                AddItemClient(locationsForSameObject, startLuName, startKeyRef, startIconHtml, xOffset, yOffset, startAlertTriggered);          
            i = j-1;
        }

        // Zoom the map
        if(addedLocations.length == 0) {
            var position = new VELatLong(defaultStartLatitude, defaultStartLongitude);
            map.SetCenterAndZoom(position, defaultStartZoomLevel);
        }
        else if(addedLocations.length == 1) {
            map.SetCenterAndZoom(addedLocations[0], 7);
        }
        else {
            map.SetMapView(addedLocations);
        }
    }
    window.external.UpdateItemsClientCompleted();
}

function AddItemClient(locations, luName, keyRef, customHtml, xOffset, yOffset, alertTriggered)  {
    var shape = null;
    if(locations.length == 1) {
        shape = new VEShape(VEShapeType.Pushpin, locations);
    }
    else if(locations.length > 1) {
        shape = new VEShape(VEShapeType.Polyline, locations);
    }
    shape.originalOffset = new VEPixel(xOffset, yOffset);
    shape.originalHtml = customHtml;
    // Bug 101593, start 
    shape.luName = luName;
    shape.keyRef = keyRef;
    shape.alertTriggered = alertTriggered;
    offsetImage(shape);
    // timeout added to avoid script error
    setTimeout(function(){itemShapeLayer.AddShape(shape);parameter = null},1);
	 // Bug 101593, end
} 

function updateImageOffset() {
   for (var i = 0; i < map.GetShapeLayerCount(); i++) {
      var shapeLayer = map.GetShapeLayerByIndex(i);
      if (shapeLayer != null) {
         for (var j = 0; j < shapeLayer.GetShapeCount(); j++) {
            var shape = shapeLayer.GetShapeByIndex(j);
            if (shape != null) {
            // Bug 101593, start
            // timeout added to avoid script error
			   setTimeout(function(){offsetImage(shape);parameter = null},1);
			   // Bug 101593, end
            }
         }
      }
   }
}

function offsetImage(shape) {
   if(shape.originalOffset) {
       var x = shape.originalOffset.x;
       var y = shape.originalOffset.y;
       var newX = x * (map.GetZoomLevel() / 19)
       var newY = y * (map.GetZoomLevel() / 19)
       var newIconHtml = shape.originalHtml.replace(/Y_OFFSET_A/g, newY + "");
       newIconHtml = newIconHtml.replace(/X_OFFSET_B/g, newX + "");
       shape.SetCustomIcon(newIconHtml);
   }
}

function ShowTitleAndDescriptionClient(luName, keyRef, title, description) {
    shape = GetShape(luName, keyRef);
    shape.SetTitle(title);
    shape.SetDescription(description);
    map.ShowInfoBox(shape);
}

function GetShape(luName, keyRef) {
    for(i=0; i< itemShapeLayer.GetShapeCount(); i++) {
        shape = itemShapeLayer.GetShapeByIndex(i);
        if(shape.luName != null && shape.keyRef != null && shape.luName == luName && shape.keyRef == keyRef) {
            return shape;
        }
    }
}

function ClearMapClicked() {
    ClearMap();
    window.external.ClearMapServer();
}

function ClearMap() {
    map.DeleteAllShapes();
    var routes = [];
    arrowRouteList = null;
}

function DisplayScalebar(displayScaleBar, distanceUnit) {
    if(displayScaleBar) {
        switch(distanceUnit) {
            case this.scaleBarDistanceUnit.Kilometers:
                map.SetScaleBarDistanceUnit(VEDistanceUnit.Kilometers);
                break;
            case this.scaleBarDistanceUnit.Miles:
                map.SetScaleBarDistanceUnit(VEDistanceUnit.Miles);            
                break;
        }
        map.ShowScalebar();
    }
    else {
        map.HideScalebar();
    }
}
                 
function UpdateQuickSearchBox(innerHtml, boxWidth) {
    RemoveQuickSearchBox()
    var savedSearchBox = document.createElement("div");                
    savedSearchBox.id = "savedSearchBox";
    savedSearchBox.className = "quickSearch"; 
    savedSearchBox.innerHTML = innerHtml; 
    var startX = (document.body.clientWidth - boxWidth)+2;                
    savedSearchBox.style.left = startX + "px";
    savedSearchBox.style.position = "absolute";
    savedSearchBox.style.width = boxWidth + "px";
    map.AddControl(savedSearchBox);
}

function WindowResize()
{
    if(map != null) {
        var windowWidth = document.documentElement.clientWidth;
        var windowHeight = document.documentElement.clientHeight;
        map.Resize(windowWidth, windowHeight); 
        
        // Only used in the main map
        var savedSearchBox = document.getElementById("savedSearchBox");
        if(savedSearchBox != null) {
            var pureWidth = savedSearchBox.style.width.substring(0, savedSearchBox.style.width.length-2);
            var startX = (windowWidth - pureWidth)+2;                
            map.DeleteControl(savedSearchBox);
            savedSearchBox.style.top = 0;
            savedSearchBox.style.left = startX + "px";
            map.AddControl(savedSearchBox);
        }
    }
}

function RemoveQuickSearchBoxClicked() {
    RemoveQuickSearchBox();
    window.external.RemoveQuickSearchBoxClickedServer();
}

function RemoveQuickSearchBox() {
    var quickSearchBox = document.getElementById("savedSearchBox");
    if(quickSearchBox != null) {
        map.DeleteControl(quickSearchBox);
    }
}

function MinimizeQuickSearchBox() {
    RemoveQuickSearchBox();
    window.external.ShowMinimizedQuickSearchBox();
}

function CreateMinimizedQuickSearchBox(innerHtml) {
    var minimizedSearchBox = document.createElement("div");                
    minimizedSearchBox.id = "savedSearchBox";
    minimizedSearchBox.className = "quickSearch"; 
    minimizedSearchBox.style.position = "absolute"; 
    minimizedSearchBox.style.width = "28px";       
    var startX = (document.body.clientWidth - 28)+2;                
    minimizedSearchBox.style.left = startX + "px";    
    minimizedSearchBox.innerHTML = innerHtml; 
    map.AddControl(minimizedSearchBox);
}

function MaximizeQuickSearchBox(innerHtml) {
    RemoveQuickSearchBox();
    window.external.InitializeQuickSearchBox();
}
         
function QuickSearchClicked(key) {
    window.external.QuickSearchSelected(key);
}

function CloseBox(elem) {
    var parent = elem.parentElement.parentElement.parentElement;
    if(parent != null) {
        parentParent = parent.parentElement;
        parentParent.removeChild(parent);
    }
}

function CenterMap(centerLat, centerLon, zoomLevel) {
    var centerPosition = new VELatLong(centerLat, centerLon);
    map.SetCenterAndZoom(centerPosition, zoomLevel);
    
    if(drawingNow == true) {

        drawingNow = false;
    }
}

function GetMapCenterLongitude() {
    return map.GetCenter().Longitude;
}

function GetMapCenterLatitude() {
    return map.GetCenter().Latitude;
}

function GetMapCenterZoomLevel() {
    return map.GetZoomLevel();
}

/* Arrow Routes */
function DrawArrowRoutes(listOfRoutes) {  
    if(arrowRouteList == null) {
        arrowRouteList = [];
    }
    if(routeExist(listOfRoutes) == false) {
        arrowRouteList.push(listOfRoutes);
    }

    if(listOfRoutes.indexOf("&abc:") !=  -1) {
        var routes = listOfRoutes.split("&abc:");
        routeList = [];
        routeCounter = 0;
       
        // Loop through the routes and assemble positions and colors
        for(i=0; i<routes.length-1; i++) {
            var routepoints = routes[i].split("&:");
            var previousPointPosition = null;
            
            // Loop through the points of each route
            for(j=0; j< routepoints.length-1; j++) {
                var routePointData = routepoints[j].split("&;");
                var pointPosition = new VELatLong(parseFloat(routePointData[0]), parseFloat(routePointData[1]));
                pointColor = new VEColor(routePointData[2], routePointData[3], routePointData[4], 1);
                
                if(previousPointPosition != null) {
                    DrawArrow(previousPointPosition, pointPosition, pointColor);           
                }
                previousPointPosition = pointPosition;
            }
        }
    }
    if(inLoop == false) {
        window.external.UpdateRoutesCompleted();
        drawingNow = false;
    }
}

function DrawArrow(startPosition, endPosition, arrowColor)
{
    var points = new Array;
    points = [startPosition, endPosition];

    // Last point in polyline array
    var anchorPoint = points[points.length - 1];
    
    // Bearing from last point to second last point in pointline array 
    var bearing = CalculateBearing(anchorPoint, points[points.length - 2]);
    var zoom = map.GetZoomLevel();
    var div = Math.pow(2,zoom);
    var resolution = 156543.04 / div;
    var arrowLength = resolution / 80;
    var lineLength = HaversineDistance(anchorPoint, points[points.length - 2])
    if(arrowLength > (lineLength / 4))
        arrowLength = (lineLength / 4);
    var arrowAngle = 15;

    // Calculate coordinates of arrow tips 
    var arrowPoint1 = CalculateCoord(anchorPoint, bearing - arrowAngle, arrowLength);
    var arrowPoint2 = CalculateCoord(anchorPoint, bearing + arrowAngle, arrowLength);

    // Go from last point in polyline to one arrow tip, then back to the last point then to the second arrow tip.
    points.push(arrowPoint1);
    points.push(anchorPoint);
    points.push(arrowPoint2);
    
    // Create a polyline that includes the points of the arrow head.
    var shapeLink = new VEShape(VEShapeType.Polyline, points);
    shapeLink.SetLineColor(arrowColor);
    shapeLink.SetTitle("Route");
    shapeLink.HideIcon();
    shapeLink.SetZIndex(1001, 1001);
    routeArrowLayer.AddShape(shapeLink);
}

var drawingNow = false;
var inLoop = false;
function ReDrawRoutes() {
    if(drawingNow == false) {
        drawingNow = true;
        if(arrowRouteList != null) {
            routeArrowLayer.DeleteAllShapes();
            
            for(l=0; l<arrowRouteList.length; l++) {
                if(l == arrowRouteList.length-1) {
                    inLoop = false;
                }
                else {
                    inLoop = true;
                }
                DrawArrowRoutes(arrowRouteList[l]);
            }
        }
    }
}

function DegtoRad(x) {
    return x * Math.PI / 180;
}

function RadtoDeg(x) {
    return x * 180 / Math.PI;
}

function CalculateCoord(origin, brng, arcLength) {
    var lat1 = DegtoRad(origin.Latitude);
    var lon1 = DegtoRad(origin.Longitude);
    var centralAngle = arcLength / earthRadius;

    var lat2 = Math.asin(Math.sin(lat1) * Math.cos(centralAngle) + Math.cos(lat1) * Math.sin(centralAngle) * Math.cos(DegtoRad(brng)));
    var lon2 = lon1 + Math.atan2(Math.sin(DegToRad(brng)) * Math.sin(centralAngle) * Math.cos(lat1), Math.cos(centralAngle) - Math.sin(lat1) * Math.sin(lat2));

    return new VELatLong(RadtoDeg(lat2), RadtoDeg(lon2));
}

function CalculateBearing(A, B) {
    var lat1 = DegtoRad(A.Latitude);
    var lon1 = A.Longitude;
    var lat2 = DegtoRad(B.Latitude);
    var lon2 = B.Longitude;
    var dLon = DegtoRad(lon2 - lon1);

    var y = Math.sin(dLon) * Math.cos(lat2);
    var x = Math.cos(lat1) * Math.sin(lat2) - Math.sin(lat1) * Math.cos(lat2) * Math.cos(dLon);

    var brng = (RadtoDeg(Math.atan2(y, x)) + 360) % 360;
    return brng;
} 

function HaversineDistance(latlong1,latlong2)
{
    var lat1 = DegtoRad(latlong1.Latitude);
    var lon1 = DegtoRad(latlong1.Longitude);
    var lat2 = DegtoRad(latlong2.Latitude);
    var lon2 = DegtoRad(latlong2.Longitude);
    var dLat = lat2-lat1;
    var dLon = lon2-lon1;
    var cordLength = Math.pow(Math.sin(dLat/2),2)+Math.cos(lat1)*Math.cos(lat2)*Math.pow(Math.sin(dLon/2),2);
    var centralAngle = 2 * Math.atan2(Math.sqrt(cordLength), Math.sqrt(1- cordLength));
    return earthRadius * centralAngle;
}

function routeExist(route) {
    if(arrowRouteList != null) {
        for(var i=0; i<arrowRouteList.length; i++) {
            if(arrowRouteList[i] == route) {
                return true;
            }
        }
        return false;
    }
}

/* Road Routes */
var routeList = null;
var routeCounter = null;
var showRouteInfoboxes;
function DrawRoadRoutes(listOfRoutes, showInfoBoxes) {
    drawingNow = true;
    showRouteInfoboxes = false;
    if(showInfoBoxes == "True") 
        showRouteInfoboxes = true;

    if(listOfRoutes.indexOf("&abc:") !=  -1) {
        var routes = listOfRoutes.split("&abc:");
        routeList = [];
        routeCounter = 0;
       
        // Loop through the routes and assemble positions and colors
        for(i=0; i<routes.length-1; i++) {
            var routepoints = routes[i].split("&:");
            var previousPointPosition = null;
            
            // Loop through the points of each route
            for(j=0; j < routepoints.length-1; j++) {

                var routePointData = routepoints[j].split("&;");
                var pointPosition = new VELatLong(parseFloat(routePointData[0]), parseFloat(routePointData[1]));
                routeColor = new VEColor(routePointData[2], routePointData[3], routePointData[4], 1);
                
                if(previousPointPosition != null) {                   
                    var route = new Route();
                    if(j == 1) {
                        route.isStart = true;
                    }
                    if(j == routepoints.length-2) {
                        route.isEnd = true;
                    }
                    route.drawInfobox = 
                    route.color = routeColor;
                    route.startPosition = previousPointPosition;
                    route.endPosition = pointPosition;
                    route.distanceCounter = j;
                    routeList.push(route);
                }
                
                previousPointPosition = pointPosition;
            }
        }
        
        // Draw the routes synchronously     
        DrawNextRoute();       
    }
}

// Class containing route information
function Route() {
    this.startPoint = null;
    this.endPoint = null;
    this.color = null;
    this.isStart = false;
    this.isEnd = false;
    this.distanceCounter = null;
}

var routeColor = null;
var isStart = null;
var isEnd = null;
var distanceCounter = null;
function DrawNextRoute() {
    if(routeCounter < routeList.length) {
        var routeOptions = new VERouteOptions();
        routeOptions.RouteCallback = OnGotRoute;
        if(globalDistanceUnit == this.scaleBarDistanceUnit.Kilometers) {
            routeOptions.DistanceUnit = VERouteDistanceUnit.Kilometer;
        }

        route = routeList[routeCounter];
        var startAndEndPoint = [];
        startAndEndPoint.push(route.startPosition);
        startAndEndPoint.push(route.endPosition);
        routeColor = route.color;

        // Set globals used by the route drawing       
        isStart = route.isStart;
        isEnd = route.isEnd;
        distanceCounter = route.distanceCounter;    

        // Trigger drawing of route
        routeCounter++;
       
        map.GetDirections(startAndEndPoint, routeOptions);
    }
    else if(routeCounter == routeList.length) {
        window.external.UpdateRoutesCompleted();
        drawingNow = false;
    }    
}

function OnGotRoute(route) { 
    var polyline = new VEShape(VEShapeType.Polyline, route.ShapePoints);
    lastRouteStart = route.ShapePoints[0];
    lastRouteEnd = route.ShapePoints[route.ShapePoints.length-1];
        
    // Draw the route line in the along the roads
    polyline.SetLineColor(routeColor);
    polyline.SetLineWidth(2);
    
    if(showRouteInfoboxes) {
        polyline.SetCustomIcon("<div style='size=auto; background:white;'><table table style='color:black; font-family:Verdana; font-size:10px; border:1px solid black;'>"
                              + "<tr><td>" + translatedOneDistance + " " + distanceCounter + ": " + Math.round(route.Distance*100)/100 + " " + translatedDistanceUnit + "</td></tr>"
                              + "<tr><td>" + GetTime(route.Time) + "</td></tr></table></div>");
    }
    else {
        polyline.HideIcon();
    }
    routeRoadLayer.AddShape(polyline);

    // Draw start flag if we are in the begining of a complete route
    if(isStart && lastRouteStart != null) {
        startPoints = [];
        startPoints.push(lastRouteStart);
        var startFlag = new VEShape(VEShapeType.Pushpin, startPoints);
        startFlag.SetCustomIcon("<img src='" + routeStartIcon + "'/>");
        routeRoadLayer.AddShape(startFlag);
    }

    // Draw end flag if we have completed an entire route
    if(isEnd && lastRouteEnd != null) {
        endPoints = [];
        endPoints.push(lastRouteEnd);
        var endFlag = new VEShape(VEShapeType.Pushpin, endPoints);
        endFlag.SetCustomIcon("<img src='" + routeEndIcon + "'/>");
        routeRoadLayer.AddShape(endFlag);
    }

    map.DeleteRoute();
    DrawNextRoute();    
}

function GetTime(time) {
    if (time == null) {
        return ("");
    }
    if (time > 60) {
        var seconds = time % 60;
        var minutes = time - seconds;
        minutes = minutes / 60;

        if (minutes > 60) {
            var minLeft = minutes % 60;
            var hours = minutes - minLeft;
            hours = hours / 60;         
            return (hours + " " + translatedHours + ", " + minLeft + " " + translatedMinutes);
        }
        else {
            return (minutes + " " + translatedMinutes);
        }
    }
    else {
        return (time + " " + translatedSeconds);
    }
}