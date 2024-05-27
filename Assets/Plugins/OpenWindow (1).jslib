var OpenWindowPlugin = {
    openWindow: function(link)
    {
    	var url = Pointer_stringify(link);
        document.onpointerup = function()
        {
        	window.open(url);
        	document.onpointerup = null;
        }
    }
};

mergeInto(LibraryManager.library, OpenWindowPlugin);