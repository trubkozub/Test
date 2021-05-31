function check() {
    var countChecked = 0;
    var quaestions = document.getElementsByName('quaestion');
    var answers = document.querySelectorAll('input');
        for (var i = 0; i < answers.length; i++) {
            if (answers[i].type == "radio" && answers[i].checked) {
                countChecked++;
            }
    }
    if (quaestions.length == countChecked) {
        var lastQ = quaestions[quaestions.length - 1].id;
        var button = document.getElementById('next');
       
        button.setAttribute("class", "btn btn-danger");
    }
}
