//https://jsfiddle.net/5o1wf1bn/1/

var rawSelector = "#CurrentRaw";
var translationSelector = "#CurrentTranslation";
var markedSelector = "#CurrentMarked";
var completionSelector = "#CurrentCompletion";

function incrementIndex(data) {
    data.IncrementIndex();
    reloadDesk(data);
}

function decrementIndex(data) {
    data.DecrementIndex();
    reloadDesk(data);
}

//function changeMarked(data, marked) {
//    data.Marked = marked;
//    reloadDesk();
//}

function reloadDesk(data) {
    $(rawSelector).text(data.CurrentRaw);
    $(translationSelector).text(data.CurrentTranslation);
    $(markedSelector).prop('checked', translationData.CurrentMarked);
    $(completionSelector).prop('checked', translationData.CurrentCompletion);
}