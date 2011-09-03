
/*
* Undertone v0.1
* Undertone image display code
* Chris Rickard 6/03/2007
* 
* Read undertone image (located in image1.js) and render as
* div's to the screen. Including zoom level.
*/
function undertone_init()
{
	var _start_datetime = new Date(); //used for time keeping
	var zoom = 2; //level to zoom the picture too
	var undertone_source = ""; //to store the html output

	
	//grab reference to container div
	container = document.getElementById("image1_container"); 
	container_top = container.offsetTop;
	container_left = container.offsetLeft;
	
	//calculate image's pixel dimensions based on zoom level
	image_width = (image1[0] * zoom);
	image_height = (image1[1] * zoom); 
	
	//retieve most common colour from undertone image source
	most_common_color = image1[2]; 

	//set container's background colour to the most common color
	container.style.backgroundColor = "#" + utclut[most_common_color];
	container.style.width = image_width + "px";
	container.style.height = image_height + "px";
	
	//pixel to start processing from (due to meta info)
	current_pixel = 3; 
	
	
	//loop through pixels y axis (height)...
	for (y = 0; y < image_height; y+=zoom)
	{
		//loop through pixels x axis (width)...
		for (x = 0; x < image_width; x+=zoom)
		{
			//if current pixel isn't the most common color, add to output...
			if( image1[ current_pixel ] != most_common_color )
			{
				undertone_source  +=  "<div class='pixel' style='width:" + zoom + "px; height:" + zoom + "px; background-color:#" + utclut[ image1[ current_pixel ] ] + "; left:" + (container_left + x) + "px; top:" + (container_top + y) + "'></div>"  ; 
				//note, appending the source appears to be roughly 2 times faster than DOM node insertion..
				}
			current_pixel++;
		} 
	}
	    
	//render source to container
	container.innerHTML = undertone_source;
	
	//calculate time taken to perform...
	var one_day = 1000;
	var _end_datetime = new Date();
	difference = (_end_datetime.getTime()-_start_datetime.getTime())/(one_day);
	
	//display render time
	document.getElementById("render_time").innerHTML = "Render Time: " + difference + ", Go Undetone Go!";
}

