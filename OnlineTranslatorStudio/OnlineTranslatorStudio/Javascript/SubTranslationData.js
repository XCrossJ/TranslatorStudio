var SubTranslationData = /** @class */ (function () {
    function SubTranslationData(conditionList) {
        var _this = this;
        if (conditionList == undefined)
            throw Error("Condition List passed is invalid. Cannot construct Sub Translation Data");
        this.IndexReference = [];
        for (var i = 0; i < conditionList.length; i++) {
            if (conditionList[i])
                this.IndexReference.push(i);
        }
        if (this.IndexReference.length == 0)
            throw Error("Condition List returned no results. Cannot construct Sub Translation Data");
        this.CurrentIndex = ko.observable(0);
        this.MaxIndex = ko.computed({
            owner: this,
            read: function () {
                return _this.IndexReference.length - 1;
            }
        });
        this.NumberOfLines = ko.computed({
            owner: this,
            read: function () {
                return _this.IndexReference.length;
            }
        });
        this.CurrentReference = ko.computed({
            owner: this,
            read: function () {
                return _this.IndexReference[_this.CurrentIndex()];
            }
        });
    }
    return SubTranslationData;
}());
//# sourceMappingURL=SubTranslationData.js.map