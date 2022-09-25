getAllMovies();

function getAllMovies() {

    $.ajax({

        type: "POST",

        url: "Questions.aspx/GetAllQuestion",

        data: "",
        //data: "{ lolo '" + lolo + "'}",
        //data: "{ timeTaken: '" + timeTaken + "',moveCount: " + moveCount + ",timeScore: " + timeScore + ",winFlag: " + winFlag + "}",

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        async: "true",

        cache: "false",

        success: function (data) {

            const tempAllQuestions = data.d;
           
            let allQuestionsDiv = document.getElementById('allMoviesDiv');
           
            document.getElementById('questCount').innerText = "Displaying: "+tempAllQuestions.length +" Questions";
            for (let i = 0; i < tempAllQuestions.length; i++) {

                let allGenres = "";
                for (let j = 0; j < tempAllQuestions[i].tagsList.length; j++) {

                    allGenres += '<button class="btn btn-sm btn-info disabled" style="margin-right:2px;">' + tempAllQuestions[i].tagsList[j].tagName+  '</button>';
                }
                let tempDiv = document.createElement('div');
        //public int userId;
        tempDiv.innerHTML = '<div class="list-group w-100"><div class="d-flex w-100 justify-content-between"><a href="answersPage.aspx?questionID=' + tempAllQuestions[i].questionID + '" class="mb-1">' + tempAllQuestions[i].questionTitle + '</a></div><p class="mb-1">' + tempAllQuestions[i].questionBody + '<div class="d-flex">' + allGenres + ' </div ><div class="d-flex "><button class="btn btn-sm btn-success disabled" style="margin-top:2px;">Votes: ' + tempAllQuestions[i].quesVoteCount + ' </br></button></div><div><p>' + tempAllQuestions[i].postDate + '</p><p>' + tempAllQuestions[i].userId + '</p></div> </div > ';


     
                allQuestionsDiv.appendChild(tempDiv);
            }

            //addCartFunctionality(tempAllMovies);

        },

        failure: function () {
            alert("not done");
        },

    });

}

document.getElementById('btnSearch').addEventListener('click', function () {


    //console.log(document.getElementById('searchField').value);
    getSearchedMovies(document.getElementById('searchField').value);

})


function getSearchedMovies(searchField) {

    $.ajax({

        type: "POST",

        url: "Questions.aspx/getSearchedQuestions",

        data: "{ searchField: '" + searchField + "'}",
        //data: "{ lolo '" + lolo + "'}",
        //data: "{ timeTaken: '" + timeTaken + "',moveCount: " + moveCount + ",timeScore: " + timeScore + ",winFlag: " + winFlag + "}",

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        async: "true",

        cache: "false",

        success: function (sData) {
            alert(sData.d);
            const tempSearchedMovies = sData.d;

            let allQuestionsDiv = document.getElementById('allMoviesDiv');
            allQuestionsDiv.innerHTML="";

            document.getElementById('questCount').innerText = "Displaying: " + tempSearchedMovies.length + " Questions";
            for (let i = 0; i < tempSearchedMovies.length; i++) {

                let allGenres = "";
                for (let j = 0; j < tempSearchedMovies[i].tagsList.length; j++) {

                    allGenres += '<button class="btn btn-sm btn-info disabled" style="margin-right:2px;">' + tempSearchedMovies[i].tagsList[j].tagName + '</button>';
                }
                let tempDiv = document.createElement('div');
                //public int userId;
                tempDiv.innerHTML = '<div class="list-group w-100"><div class="d-flex w-100 justify-content-between"><a href="answersPage.aspx?questionID=' + tempSearchedMovies[i].questionID + '" class="mb-1">' + tempSearchedMovies[i].questionTitle + '</a></div><p class="mb-1">' + tempSearchedMovies[i].questionBody + '<div class="d-flex">' + allGenres + ' </div ><div class="d-flex "><button class="btn btn-sm btn-success disabled" style="margin-top:2px;">Votes: ' + tempSearchedMovies[i].quesVoteCount + ' </br></button></div><div><p>' + tempSearchedMovies[i].postDate + '</p><p>' + tempSearchedMovies[i].userId + '</p></div> </div > ';



                allQuestionsDiv.appendChild(tempDiv);
            }

            //addCartFunctionality(tempAllMovies);

        },

        failure: function () {
            alert("not done");
        },

    });

}
//for (const btn of document.querySelectorAll('.vote')) {
//    btn.addEventListener('click', event => {
//        event.currentTarget.classList.toggle('on');
//    });
//}