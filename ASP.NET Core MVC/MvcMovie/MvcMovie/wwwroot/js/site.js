function preview() {

    // Use jquery to get the value of the dd element with an id of "title".
    var movie = $("#title").text();

    // Trim whitespaces before and after the string. The string comparison will not work otherwise.
    movie = movie.trim();

    if (movie === "The RM") {
        document.getElementById("movie_preview").src = "https://m.media-amazon.com/images/M/MV5BMTI4NzQ1OTMyNV5BMl5BanBnXkFtZTYwMTE1NzQ3._V1_UX182_CR0,0,182,268_AL_.jpg";
    }
    else if (movie === "Other Side of Heaven") {
        document.getElementById("movie_preview").src = "https://duckduckgo.com/i/51bc4023.png";
    }
    else if (movie === "Meet the Mormons") {
        document.getElementById("movie_preview").src =
            "https://duckduckgo.com/i/f58e1caa.jpg";
    }
    else {
        document.getElementById("movie_preview").src =
            "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fcontent6.flixster.com%2Fmovie%2F11%2F03%2F44%2F11034408_det.jpg&f=1&nofb=1";
    }
}

preview()