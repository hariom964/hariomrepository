(function () {
    
    var ele = $("#username");
    ele.text("Hari");
    var main = $("#main");
    //main.on("mouseenter", function () {
    //    main.style["background-color"] = "#888";
    //});
    main.onmouseleave = function () {
        main.style["background-color"] = "";
    };

    var $sidebarandwrapper = $("#sidebar, #wrapper");
    $("#sidebartoggle").on("click", function () {
        $sidebarandwrapper.toggleClass("hide-sidebar");
        if ($sidebarandwrapper.hasClass("hide-sidebar")){
        $(this).text("Show Sidebar");
        } else {
            $(this).text("HIde Sidebar");
        }
    });
})();
