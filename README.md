# Unity_sensor-Visualization
Program for 6-Axes sensor's moving visualization



After building the unity project, create a "data" folder in the same location of the unity program. Put several txt files named "sensor_index.txt" and one file named "InitialPosition.txt" in data folder. Then the unity project will present the location of each sensor.

"sensor_index.txt" contains the position(x,y,z,axes in cm) and ypr angle (degree) of each sensor, sampled every 100ms, following with the time tag and a status string used for visualization label.

"InitialPosition.txt" contains the initial position(x,y,z,axes in cm) of each sensor.


Check the "data" folder in the repository as an example.
