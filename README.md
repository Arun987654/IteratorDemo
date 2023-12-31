# Overview
Through this project, the design pattern 'Iterator' has been demonstrated. The Iterator provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation. The project serves as a console-based cricket scorecard application which in turn depicts the design pattern. Users can access/view the scores of each player without actually knowing the actual implementation of the scorecard, which is an aggregate object.  
# Design
The project defines an interface IPlayerIterator which assists in the traversal of the aggregate object, the list of Players. The PlayerIterator class implements this interface and maintains an index to keep track of traversal of the list. The Player class is initialised with some data, which corresponds to the score of a particular player. The IScorecard interface defines the aggregate interface which includes creating an iterator for the scorecard. The Cricinfo class implements this interface and provides a method to add players. The program class acts as the user interface. The crux here is that users can traverse the scorecard using the iterator without knowing the internal structure of the scorecard, the list of players hence demonstrating the design pattern.

![Iterator](https://github.com/Arun987654/IteratorDemo/assets/101346220/2eba4dd2-85aa-442f-83a7-7a923b8af718)

# Environment
This project builds and runs with Visual Studio Community 2022 when the required workloads are installed.
