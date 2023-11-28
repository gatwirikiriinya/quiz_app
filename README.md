# Quiz Application

This application allows users to take quizzes on various topics. It includes a list of available quizzes, and users can choose a quiz to start answering questions.

## How to Run the Application
Clone the repository:

git clone https://github.com/gatwirikiriinya/quiz_app.git

## Open Solution in Visual Studio:

Open Visual Studio.
Click on "File" > "Open" > "Project/Solution."
Navigate to the cloned repository and open the solution file (.sln).

## Build and Run:

Build the solution by clicking on "Build" > "Build Solution."
Run the application by clicking on the "Start" button (green triangle) or pressing F5.

## How to Use the Application

### AvailableQuizes: Quiz Selection
1. When you launch the application, you will be presented with AvailableQuizes.
2. AvailableQuizes displays a list of available quizzes.
3. Only one quiz is active.

![image](https://github.com/gatwirikiriinya/quiz_app/assets/106272752/064cc1b5-a2fe-4fc2-96a2-67afa585fefc)

Click on it to proceed to the QuizForm .

### QuizForm: Quiz Questions
1. QuizForm displays questions for the selected quiz.
2. Each question is presented one at a time.
3. Select an answer by clicking the corresponding button.
4. Immediate feedback is given for each answer.
5. Correct answers are highlighted in green.
6. Incorrect answers are highlighted in red.
7. The quiz progresses to the next question automatically.

 ![image](https://github.com/gatwirikiriinya/quiz_app/assets/106272752/5a78e54f-8c6f-4e5d-8ed7-3fbffe6fa8f2)


   
After completing the quiz, a summary is displayed, showing the number of correct answers, the percentage, and the weighted score.

![image](https://github.com/gatwirikiriinya/quiz_app/assets/106272752/0e570662-5bd1-47e2-b351-4a395244d13e)

  
## Additional Features

### Retaking the Quiz:

After completing a quiz on QuizForm, users have the option to click "YES" to play again or "NO"  to end the QUIZFORM .
The application resets the score and question number for a new quiz.

### Exception Handling:

The application uses exception handling to catch errors and display meaningful error messages to the user.

### Quiz Models
The application uses the following models for quizzes and questions:

#### Quiz Model:

1. Quiz class with properties Title and Questions.
2. Questions is a list of Question objects.

#### Question Model:

1. Question class with properties Text, Options, CorrectOptionIndex.

#### Testing Strategy
The application has been tested using unit tests for individual methods and integration tests for interactions between different components. Test cases cover normal use cases, boundary conditions, and potential error cases.

### Useful links
##### [Application Design](https://docs.google.com/document/d/1YnZtM7pGt-My9qoq714xQSB3Aup39tUTWoNtyAK_ACw/edit?usp=sharing)
##### [Testing strategy](https://docs.google.com/document/d/1dm269RzG6uN6rEqwMLZMQOD3eemgW2csFQWI1mZywJo/edit?usp=sharing)
##### [User manual](https://docs.google.com/document/d/1bhNaTuW7Rbvjl1kat7wnp3YjoWhGT5Cb_EQKTLt1R2M/edit?usp=sharing)
