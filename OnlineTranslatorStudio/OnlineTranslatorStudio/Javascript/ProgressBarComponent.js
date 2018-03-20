//
//http://www.riptutorial.com/knockout-js/example/21500/progress-bar--boostrap-
//
ko.components.register('progress-bar', {
    viewModel: function (params) {
        var that = this;
        // progress is a numeric value between 0 and 100
        that.progress = params.progress;
        that.progressPercentual = ko.computed(function () {
            return '' + ko.utils.unwrapObservable(that.progress) + '%';
        });
    },
    template: '<div class="progress"> <div data-bind="attr:{\'aria-valuenow\':progress}, style:{width:progressPercentual}, text:progressPercentual" class="progress-bar bg-success progress-bar-striped active" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="min-width: 2em;"></div> </div>'
});
//# sourceMappingURL=ProgressBarComponent.js.map