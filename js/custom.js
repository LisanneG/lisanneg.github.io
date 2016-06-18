$(document).ready(function(){
	// Als er op het menuknop wordt gedrukt
    $("#menuKnop").click(function(){
    	// Als de display none is verschijnt het menu
    	if ($('#menu').css('display') == 'none') {
    		$("#menu").slideDown("slow");
            $("#text").slideUp("slow");
    	} else {
    		// Als dat niet zo is wordt het menu ontzichtbaar
    		$("#menu").slideUp("slow");
            $("#text").slideDown("slow");
    	};
    });
    // Checkt hoe groot het scherm is
    $(window).resize(function(){
    	// Als het grooter is dan 912 verschijnt het menu weer
    	if ($(window).width() > 721) {
    		$("#menu").show();
            $("#text").show();
    	};
    });
});