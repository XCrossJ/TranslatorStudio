//https://jsfiddle.net/5o1wf1bn/1/

var nameSelector = "#ProjectName";

var indexSelector = "#CurrentIndex";
var linesSelector = ".NumberOfLines";

var rawSelector = "#CurrentRaw";
var translationSelector = "#CurrentTranslation";
var markedSelector = "#CurrentMarked";
var completionSelector = "#CurrentCompletion";

function incrementIndex(data) {
    console.log(data);
    data.IncrementIndex();
    reloadDesk(data);
}

function decrementIndex(data) {
    console.log(data);
    data.DecrementIndex();
    reloadDesk(data);
}

//function changeMarked(data, marked) {
//    data.Marked = marked;
//    reloadDesk();
//}

function reloadDesk(data) {
    $(nameSelector).text(data.ProjectName);

    console.log(data.currentIndex + 1);
    $(indexSelector).text(data.currentIndex + 1);
    $(linesSelector).text(data.NumberOfLines);
    
    $(rawSelector).text(data.CurrentRaw);
    $(translationSelector).text(data.CurrentTranslation);
    $(markedSelector).prop('checked', data.CurrentMarked);
    $(completionSelector).prop('checked', data.CurrentCompletion);
}