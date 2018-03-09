# Unity_sensorVisualization
Program for 6-Axes sensor's moving visualization

demo gif:
![](https://github.com/ntu-as-cooklab/Unity_sensorVisualization/master/README.md)




After building the unity project, create a **"data" folder** in the same location of the unity program. Put several txt files named "sensor_index.txt" and one file named "InitialPosition.txt" in data folder. Then the unity project will present the location of each sensor.

**"sensor_index.txt"** contains the position(x,y,z,axes in cm) and ypr angle (degree) of each sensor, sampled every 100ms, following with the time tag and a status string used for visualization label. The unity program will detect how many files in the data folder and create the correspondent sensor images in the tree scene.    
"InitialPosition.txt" contains the initial position(x,y,z,axes in cm) of each sensor. For example, if you create 5 "sensor_index.txt", the there should be 5 lines in "InitialPosition.txt".

Check the "data" folder in the repository as an example.



There are two scene in the unity project. The "tree" scene present all the sensors we have at the same time, and show the time tag in "sensor_index.txt".After pressing "Choose" button and choose one of the sensor, the project will change to "single_sensor" scene, which present one single sensor with an Cartesian coordinate (cm).

As for the script,
"Axis" and "Axis_2" draw the Cartesian coordinate, "Scale" create the number tag on the coordinate.
"SensorCreater" will create Box objects according to "sensor_index.txt" in datat folder.
"Box_Move" load the sensors' position from txt files, and "Box_line" create the blue line drawing on the sensor passage.
"Button" contains all the button's script, and "Label" controls the time and acceleration label.
"CamaraMove" enables user to move camera position by pressing and moving the mouse, and scroll the wheel for changing the distance. Adjust the "(min/max)distance" to change the initial and min/max camera position relatives to the origin of the Cartesian coordinate.

If the user wants to change the "data" folder's name, then change the "path" variable in "SensorCreater"and "Box_Move", in line 9 and 106 respectively.
