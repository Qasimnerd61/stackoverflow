getAllMovies();
function getAllMovies() {

    $.ajax({

        type: "POST",

        url: "Questions.aspx/getAllQuestions",

        data: "",
        //data: "{ lolo '" + lolo + "'}",
        //data: "{ timeTaken: '" + timeTaken + "',moveCount: " + moveCount + ",timeScore: " + timeScore + ",winFlag: " + winFlag + "}",

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        async: "true",

        cache: "false",

        success: function (data) {

            const tempAllMovies = data.d;
            alert(data.d);

            let allMoviesDiv = document.getElementById('allMoviesDiv');

            for (let i = 0; i < tempAllMovies.length; i++) {

                let allGenres = "";
                for (let j = 0; j < tempAllMovies[i].genreList.length; j++) {

                    allGenres = allGenres + " " + tempAllMovies[i].genreList[j].name /*+ "<br> "*/;
                }



                let tempDiv = document.createElement('div');
                tempDiv.innerHTML = '<div class="col mb-5 movieDiv"> <div class="card h-100"> <!-- Product image--> <img class="card-img-top" src="../MoviePosters/' + tempAllMovies[i].poster + '" alt="..." /> <!-- Product details--> <div class="card-body p-4"> <div class="text-center"> <!-- Product name--> <h5 class="fw-bolder">' + tempAllMovies[i].name + '</h5> <div class="badge bg-secondary muted mb-3">' + allGenres + '</div><!-- Product price--><div>$' + tempAllMovies[i].price + '.00</div></div> </div> <!-- Product actions--> <div class="card-footer p-4 pt-0 border-top-0 bg-transparent"> <div class="text-center"><a class="btn btn-outline-dark mt-auto btnCart" href="#">Add to cart</a></div> </div> </div> </div>';

                allMoviesDiv.appendChild(tempDiv);
            }




            addCartFunctionality(tempAllMovies);

        },

        failure: function () {
            alert("not done");
        },

    });

}