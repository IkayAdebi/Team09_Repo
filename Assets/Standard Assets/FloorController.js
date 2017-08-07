#pragma strict
import Phidgets;

var instructions : GUIText;

private var motionFloor : Analog;


//23
//01

function Start () {
	motionFloor = new Analog();
    motionFloor.open();
    motionFloor.waitForAttachment(1000);
//    instructions.text = " Up Arrow = Front Up \n Down Arrow = Back Up \n Left Arrow = Left Up \n Right Arrow = Right Up \n Page Up = All Up \n Page Down = All Down";
}



function Update () {
//	if(Input.GetKeyDown(KeyCode.UpArrow)){
//        Floor("front");
//	}
//	if(Input.GetKeyDown(KeyCode.DownArrow)){
//       	Floor("back");
//	}
//	if(Input.GetKeyDown(KeyCode.LeftArrow)){
//        Floor("left");
//	}
//	if(Input.GetKeyDown(KeyCode.RightArrow)){
//       	Floor("right");
//	}
//	if(Input.GetKeyDown(KeyCode.PageUp)){
//        Floor("up");
//	}
//	if(Input.GetKeyDown(KeyCode.PageDown)){
//       	Floor("down");
//	}
}

function turnRight (){
	
	motionFloor.outputs[1].Voltage = 0.0F;
	motionFloor.outputs[3].Voltage = 0.0F;
	motionFloor.outputs[2].Voltage = 10.0F;
	motionFloor.outputs[0].Voltage = 10.0F;

}

function turnLeft (){
	
	motionFloor.outputs[0].Voltage = 0.0F;
	motionFloor.outputs[2].Voltage = 0.0F;
	motionFloor.outputs[3].Voltage = 10.0F;
	motionFloor.outputs[1].Voltage = 10.0F;

}

function lookUp (){
	
	motionFloor.outputs[2].Voltage = 10.0F;
	motionFloor.outputs[3].Voltage = 10.0F;
}



function lookDown (){
	
	motionFloor.outputs[2].Voltage = 0.0F;
	motionFloor.outputs[3].Voltage = 0.0F;
	
	

}
function pull (){
	
	motionFloor.outputs[0].Voltage = 0.0F;
	motionFloor.outputs[1].Voltage = 0.0F;
	motionFloor.outputs[2].Voltage = 10.0F;
	motionFloor.outputs[3].Voltage = 10.0F;
	
}

function push (){
	
	motionFloor.outputs[0].Voltage = 10.0F;
	motionFloor.outputs[1].Voltage = 10.0F;
	motionFloor.outputs[2].Voltage = 0.0F;
	motionFloor.outputs[3].Voltage = 0.0F;
	
}



function fullVoltage (){
	motionFloor.outputs[0].Voltage = 10.0F;
	motionFloor.outputs[1].Voltage = 10.0F;
	motionFloor.outputs[2].Voltage = 10.0F;
	motionFloor.outputs[3].Voltage = 10.0F;
}
function halfVoltage (){
	motionFloor.outputs[0].Voltage = 5.0F;
	motionFloor.outputs[1].Voltage = 5.0F;
	motionFloor.outputs[2].Voltage = 5.0F;
	motionFloor.outputs[3].Voltage = 5.0F;
}
function enable (){
	motionFloor.outputs[0].Enabled = true;
	motionFloor.outputs[1].Enabled = true;
	motionFloor.outputs[2].Enabled = true;
	motionFloor.outputs[3].Enabled = true;
}


function move (index : int, voltage : float){
	motionFloor.outputs[index].Enabled = true;
	motionFloor.outputs[index].Voltage = voltage;
}


function getVoltage(index : int): float {
	return motionFloor.outputs[index].Voltage;
}


function disable (){
	motionFloor.outputs[0].Enabled = false;
	motionFloor.outputs[1].Enabled = false;
	motionFloor.outputs[2].Enabled = false;
	motionFloor.outputs[3].Enabled = false;
}
function zeroVoltage (){
	motionFloor.outputs[0].Voltage = 0.0F;
	motionFloor.outputs[1].Voltage = 0.0F;
	motionFloor.outputs[2].Voltage = 0.0F;
	motionFloor.outputs[3].Voltage = 0.0F;
}

function Floor( key : String ) {
	switch ( key ) {
		case "down" : 
			motionFloor.outputs[0].Enabled = false;
			motionFloor.outputs[1].Enabled = false;
			motionFloor.outputs[2].Enabled = false;
			motionFloor.outputs[3].Enabled = false;
			break;
		case "up" : 
			motionFloor.outputs[0].Enabled = true;
			motionFloor.outputs[1].Enabled = true;
			motionFloor.outputs[2].Enabled = true;
			motionFloor.outputs[3].Enabled = true;
			break;
		case "front" :
			motionFloor.outputs[0].Enabled = false;
			motionFloor.outputs[1].Enabled = false;
			motionFloor.outputs[2].Enabled = true;
			motionFloor.outputs[3].Enabled = true;
			break;
		case "back" :
			motionFloor.outputs[0].Enabled = true;
			motionFloor.outputs[1].Enabled = true;
			motionFloor.outputs[2].Enabled = false;
			motionFloor.outputs[3].Enabled = false;
			break;
		case "left" :
			motionFloor.outputs[0].Enabled = true;
			motionFloor.outputs[1].Enabled = false;
			motionFloor.outputs[2].Enabled = false;
			motionFloor.outputs[3].Enabled = true;
			break;
		case "right" :
			motionFloor.outputs[0].Enabled = false;
			motionFloor.outputs[1].Enabled = true;
			motionFloor.outputs[2].Enabled = true;
			motionFloor.outputs[3].Enabled = false;
			break;
	}
}