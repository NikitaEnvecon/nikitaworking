// Enumerations 
var dashBoardSize = {"Hide" : 0, "Tiny" : 1, "Small" : 2, "Normal" : 3};
var scaleBarDistanceUnit = {"Kilometers" : 0, "Miles" : 1};

// Fields
var map = null;
var currentMouseArgs = null;
var currentShape = null;

// Callbacks
window.onload = OnLoad;

function OnLoad() {
    window.external.InitializeMapServer();
    //InitializeMapClient(1,1,2, true, 0, "Set Position", "Set Start Position", "Switch to List Mode");
}

function hidePopupMenu()
{
    var menu = document.getElementById('popupmenu').style.display='none';
}

function showPopupMenu(e)
{
    ShowSubMenu(null);
    var x = map.GetLeft();
    var y = map.GetTop();
    var menu = document.getElementById('popupmenu');
    menu.style.display='block'; 
    menu.style.left = (e.mapX + x) + "px";
    menu.style.top = (e.mapY + y) + "px";
}

function prepMenu()
{
    navRoot = document.getElementById("popupmenu");
    var items = navRoot.getElementsByTagName('li');
    for (i=0; i<items.length; i++)
    {
      node = items[i];
      if (node.nodeName=="LI")
      {
      node.onmouseover = function()
      {
        this.className+=" over"; //Show the submenu
      }
      node.onmouseout=function()
      {
        if (this.className.indexOf('pmenu') > 0)
        {
        this.className="pmenu";
        }
        else {
        this.className = "";
        }
      }
      }
    }
}

function ShowSubMenu(menuToShow) {
    // Hide all sub menu items
    var navRoot = document.getElementById("popupmenu");
    var arrChildren = navRoot.childNodes;
    for(i=0;i<arrChildren.length;i++) {
        if(arrChildren[i].tagName == 'LI' && arrChildren[i].lastChild != null && arrChildren[i].lastChild.tagName == 'UL') {                        
            arrChildren[i].lastChild.style.display='none'; 
        }
    } 
     
    if(menuToShow != null) {    
        // Show the current menu
        subMenu = menuToShow.parentNode.lastChild.style.display='block'; 
    } 
}

function SetStartPosition() {
    pixel = new VEPixel(currentMouseArgs.mapX, currentMouseArgs.mapY);
    var LL = map.PixelToLatLong(pixel);
    window.external.SetStartPosition(LL.Longitude, LL.Latitude, map.GetZoomLevel());
}

function OnClick(e)
{
    currentMouseArgs = e;
    currentShape = map.GetShapeByID(e.elementID);

    if(e.rightMouseButton) {
        if(currentShape != null)    
            document.getElementById("contextMenu").innerHTML = window.external.GenerateContextMenu(currentShape.positionID);
        else
            document.getElementById("contextMenu").innerHTML = window.external.GenerateContextMenu(null);
        prepMenu();
        showPopupMenu(e);
    }
    if(e.leftMouseButton) {
        if(document.getElementById("contextMenu").innerHTML != "") {
            hidePopupMenu();
        }
        
        if(currentShape != null) {
            // Only used in the attachment panel
            if(currentShape.positionID != null) {
                window.external.ObjectClicked(currentShape.positionID);
            } 
            // Only used in the main map
            else if(currentShape.luName != null && currentShape.keyRef != null) {
                window.external.ObjectClicked(currentShape.luName, currentShape.keyRef);
            }
            else if(currentShape.cluster != null) {
                ClusterClicked(currentShape, e);
            }
        }
    }
}

function OnMouseOver(e)
{
    if (e.elementID)
    {
        SetZIndex(e.elementID, 1);
        return true;
    }
}

function OnMouseOut(e)
{
    if (e.elementID)
    {
        SetZIndex(e.elementID, -1);
    }
}

function SetZIndex(markerId, delta)
{
    // We could use shape.SetZIndex here, but it may create problems with onmouseout, so
    // we use a different approach, by directly setting the zIndex to the element.
    var currentShape = map.GetShapeByID(markerId);
    if (currentShape && currentShape.GetPrimitive)
    {
        var shapeElem = document.getElementById(currentShape.GetPrimitive(0).iid);
        if (shapeElem && shapeElem.style)
        {
            shapeElem.style.zIndex = parseInt(shapeElem.style.zIndex) + delta;
        }
    }
}
