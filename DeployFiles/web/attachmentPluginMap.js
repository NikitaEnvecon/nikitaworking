var defaultStartLatitude = null;
var defaultStartLongitude = null;
var defaultStartZoomLevel = null;
var positionLayer

window.onresize = WindowResize;

//104570, start
var translatedKeyErrorTxt;
function InitializeMapClient(key, startingLongitude, startingLatitude, startingZoomLevel, displayScaleBar, distanceUnit, keyerror) {
    //BugId 96988, start
    map = new VEMap('virtualMap');
    map.AttachEvent("oncredentialsvalid", MyHandleKeyValid);
    map.AttachEvent("oncredentialserror", MyHandleKeyError);
    map.SetCredentials(key);
    //BugId 96988, end
      
    defaultStartLatitude = startingLatitude;
    defaultStartLongitude = startingLongitude;
    defaultStartZoomLevel = startingZoomLevel;
    translatedKeyErrorTxt = keyerror;
  
    var startingPoint = new VELatLong(startingLatitude, startingLongitude);
    var mapOptions = new VEMapOptions();
    mapOptions.EnableBirdseye = false;
    map.LoadMap(startingPoint, startingZoomLevel, null, null, null, false, null, mapOptions);

    positionLayer = new VEShapeLayer();
    map.AddShapeLayer(positionLayer);
    var options =  new VEClusteringOptions(); 
    positionLayer.SetClusteringConfiguration(VEClusteringType.Grid, options);
    document.getElementById('MSVE_obliqueNotification').innerHTML = "";
    
    if(displayScaleBar) {
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
    WindowResize();
    window.external.UpdateMap();
}
//104570, end

//BugId 96988, start
function MyHandleKeyValid() {
}

//104570, start
function MyHandleKeyError() {
    alert(translatedKeyErrorTxt);
}
//104570, end
//BugId 96988, end

function WindowResize()
{
    if(map != null) {
        var windowWidth = document.documentElement.clientWidth;
        var windowHeight = document.documentElement.clientHeight;
        map.Resize(windowWidth, windowHeight); 
    }
}

function SwitchToListView() {
    window.external.SwitchPanelView(false);
}

function AddPosition() {
	//BugId 93387, start
	pixel = new VEPixel(currentMouseArgs.mapX, currentMouseArgs.mapY+5);
    var LL = map.PixelToLatLong(pixel);
    var pixelForPin = new VEPixel(currentMouseArgs.mapX, currentMouseArgs.mapY);
    var LLforPin = map.PixelToLatLong(pixelForPin);
    window.external.AddPositionWithPin(LL.Longitude, LL.Latitude, LLforPin.Longitude, LLforPin.Latitude);
	//BugId 93387, end
}

function AddPositionClient(positionID, latitude, longitude, iconHtml)  {
    var locations = [];
    position = new VELatLong(parseFloat(latitude), parseFloat(longitude));
    locations.push(position);
    var shape = new VEShape(VEShapeType.Pushpin, locations);
    shape.SetCustomIcon(iconHtml);
    shape.positionID = positionID;
    positionLayer.AddShape(shape);
}

function RemovePosition(positionID) {
    var shape = GetShape(positionID);
    positionLayer.DeleteShape(shape);
    window.external.RemovePosition(positionID);
}

function UpdateEmptyMap(startLatitude, startLongitude, startZoomLevel) {
    map.DeleteAllShapes();
    var startingPoint = new VELatLong(startLatitude, startLongitude);
    map.SetCenter(startingPoint);
    map.SetZoomLevel(startZoomLevel);
}

function UpdatePositionsClient(listOfPositions, iconHtml) {
    map.DeleteAllShapes();
    if(listOfPositions.indexOf("&:") !=  -1) {       
        var positions = listOfPositions.split("&:");
        var addedLocations = [];
        
        // Draw positions
        for(i=0; i<positions.length-1; i++) {
            var positionString = positions[i].split("&;");
            var position = new VELatLong(parseFloat(positionString[1]), parseFloat(positionString[2]));
            addedLocations.push(position);
            AddPositionClient(positionString[0], positionString[1], positionString[2], iconHtml); 
        }
        
        // Zoom the map
        if(addedLocations.length == 1) {
            map.SetCenterAndZoom(addedLocations[0], 7);
        }
        else {
            map.SetMapView(addedLocations);
        }
    }
}

function NavigateToLargeMapClient() {
    window.external.NavigateToLargeMap();
}

function ShowTitleAndDescriptionClient(positionID, title, description) {
    shape = GetShape(positionID);
    shape.SetTitle(title);
    shape.SetDescription(description);
    map.ShowInfoBox(shape);
}

function GetShape(positionID) {
    for(i=0; i< positionLayer.GetShapeCount(); i++) {
        shape = positionLayer.GetShapeByIndex(i);
        if(shape.positionID != null && shape.positionID == positionID) {
            return shape;
        }
    }
}

function SearchLocation() {
    window.external.SearchLocationServer();
}

function CenterMap(northEastLat, northEastLon, southWestLat, southWestLon) {
    var northEastPosition = new VELatLong(northEastLat, northEastLon);
    var southWestPosition = new VELatLong(southWestLat, southWestLon);    
    var locations = [];
    locations.push(northEastPosition);
    locations.push(southWestPosition);
    map.SetMapView(locations);
}