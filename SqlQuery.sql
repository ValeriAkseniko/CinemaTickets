
--Написать запрос, который возвращает из таблицы PossibleAnswers только те записи, в которых IsRight истина
use CourseTestsDB
select *
from PossibleAnswers
where IsRight = 1;

--Написать запрос, который возвращает из таблицы Questions только те записи, в которых заполнено поле Description
use CourseTestsDB
select *
from Questions
where Description is not null;

--Users: Вывести только FullName, отсортировать  По FullName
use CourseTestsDB
select FullName
from Users
order by FullName;

--PossibleAnswer: вывести только Name и IsRight, отсортировать по IsRight
use CourseTestsDB
select Name,IsRight
from PossibleAnswers
order by IsRight;

--Написать запрос, который возвращает список вопросов, для каждого вопроса его тест и курс.
--QuestionId, QuestionName, TestId, TestName, CourseId, CourseName
use CourseTestsDB
select Questions.Id as QuestionsId,
  Questions.Name as QuestionsName,
  Tests.Id as TestsId,
  Tests.Name as TestsName,
  Courses.Id as CourseId,
  Courses.Name as CourseName
from Questions join Tests on Questions.TestId = Tests.Id
join Courses on Courses.Id = Tests.CourseId

--Написать запрос, который возвращает список ответов, для каждого ответа его вопрос, и тест.
--PossibleAnswerId, Name, IsRight, QuestionId, QuestionName, TestId, TestName
use CourseTestsDB
select Questions.Id as QuestionsId,
  Questions.Name as QuestionsName,
  Tests.Id as TestsId,
  Tests.Name as TestsName,
  PossibleAnswers.Id as PossibleAnswersId,
  PossibleAnswers.Name as PossibleAnswersName,
  PossibleAnswers.IsRight as PossibleAnswersIsRight
from PossibleAnswers join Questions on PossibleAnswers.QuestionId = Questions.Id
join Tests on Questions.TestId = Tests.Id

--Написать запрос, который возвращает список правильных ответов, для каждого ответа его вопрос, и тест.
--PossibleAnswerId, Name, Description, QuestionId, QuestionName, TestId, TestName
use CourseTestsDB
select Questions.Id as QuestionsId,
  Questions.Name as QuestionsName,
  Tests.Id as TestsId,
  Tests.Name as TestsName,
  PossibleAnswers.Id as PossibleAnswersId,
  PossibleAnswers.Name as PossibleAnswersName,
  PossibleAnswers.IsRight as PossibleAnswersIsRight
from PossibleAnswers join Questions on PossibleAnswers.QuestionId = Questions.Id
join Tests on Questions.TestId = Tests.Id
where PossibleAnswers.IsRight = 1;

--Написать запрос, который:
--а) по Id вопроса считает количество правильных ответов
use CourseTestsDB;
select COUNT(*) as CountRightAnswers 
from PossibleAnswers
where IsRight = 1 and QuestionId = '3F823C86-FEBD-4C26-97E7-EB9880235ABA';

--б) по Id тест считает количество правильных ответов
select COUNT(*) as CountRightAnswers 
from PossibleAnswers
join Questions on PossibleAnswers.QuestionId = Questions.Id
where IsRight = 1 and TestId = '611DEF89-9041-4CB3-A1BE-094B26E00794';

--в) по Id курса считает количество правильных ответов
select COUNT(*) as CountRightAnswers 
FROM PossibleAnswers
join Questions on PossibleAnswers.QuestionId = Questions.Id
join Tests on Questions.TestId = Tests.Id
where IsRight = 1 and CourseId = '168C0A97-7464-4F82-91C2-FF28476FA17C';

--Написать запрос, который выводит список вопросов (его id и название) и его кол-во правильных ответов
use CourseTestsDB;
select QuestionId, 
(select Name from Questions where Id = QuestionId) as QuestionName,
COUNT(*) as CountRightAnswers
from PossibleAnswers
where IsRight = 1
group by QuestionId
