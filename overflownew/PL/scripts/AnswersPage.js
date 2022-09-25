getAllMovies();
getAllAnswers();
function getAllMovies() {
    var text = document.getElementById("Label1").innerHTML;
    $.ajax({

        type: "POST",
        url: "answersPage.aspx/GetQuestion",
        data: "{ id: '" + text + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        async: "true",

        cache: "false",

        success: function (data) {

            const tempAllQuestions = data.d;

            let allQuestionsDiv = document.getElementById('allMoviesDiv');

            //document.getElementById('questCount').innerText = "Displaying: " + tempAllQuestions.length + " Questions";


                //let allGenres = "";
                //for (let j = 0; j < tempAllQuestions.tagsList.length; j++) {

                //    allGenres += '<button class="btn btn-sm btn-info disabled" style="margin-right:2px;">' + tempAllQuestions.tagsList[j].tagName + '</button>';
                //}
                let tempDiv = document.createElement('div');
                //public int userId;
                tempDiv.innerHTML = '<div class="list-group w-100"><div class="d-flex w-100 justify-content-between"><a href="answersPage.aspx?questionID=' + tempAllQuestions.questionID + '" class="mb-1">' + tempAllQuestions.questionTitle + '</a></div><p class="mb-1">' + tempAllQuestions.questionBody + ' </div ><div class="d-flex "><button class="btn btn-sm btn-success disabled" style="margin-top:2px;">Votes: ' + tempAllQuestions.quesVoteCount + ' </br></button></div><div><p>' + tempAllQuestions.postDate + '</p><p>' + tempAllQuestions.userId + '</p></div> </div > ';



                allQuestionsDiv.appendChild(tempDiv);
          

            //addCartFunctionality(tempAllMovies);

        },

        failure: function () {
            alert("not done");
        },

    });

}

function getAllAnswers() {
    var text = document.getElementById("Label1").innerHTML;
    $.ajax({

        type: "POST",

        url: "answersPage.aspx/GetAnswers1",

        data: "{ id: '" + text + "'}",
        //data: "{ lolo '" + lolo + "'}",
        //data: "{ timeTaken: '" + timeTaken + "',moveCount: " + moveCount + ",timeScore: " + timeScore + ",winFlag: " + winFlag + "}",

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        async: "true",

        cache: "false",

        success: function (data) {

            const tempAllQuestions = data.d;

            let allQuestionsDiv = document.getElementById('allAnswersDiv');

            document.getElementById('questCount').innerText = "Displaying: " + tempAllQuestions.length + " Questions";
            for (let i = 0; i < tempAllQuestions.length; i++) {

                //let allGenres = "";
                //for (let j = 0; j < tempAllQuestions[i].tagsList.length; j++) {

                //    allGenres += '<button class="btn btn-sm btn-info disabled" style="margin-right:2px;">' + tempAllQuestions[i].tagsList[j].tagName + '</button>';
                //}
                let tempDiv = document.createElement('div');
                //public int userId;
                tempDiv.innerHTML = '<div class="list-group w-100"><div class="d-flex w-100 justify-content-between"></div><p class="mb-1">' + tempAllQuestions[i].answerBody + '<div class="d-flex">' + tempAllQuestions[i].ansStatus + ' </div ><div class="d-flex "><button class="btn btn-sm btn-success disabled" style="margin-top:2px;">Votes: ' + tempAllQuestions[i].ansVoteCount + ' </br></button></div><div><p>' + tempAllQuestions[i].ansPostDate + '</p><p>' + tempAllQuestions[i].userID + '</p></div> </div > ';



                allQuestionsDiv.appendChild(tempDiv);
            }

            //addCartFunctionality(tempAllMovies);

        },

        failure: function () {
            alert("not done");
        },

    });

}