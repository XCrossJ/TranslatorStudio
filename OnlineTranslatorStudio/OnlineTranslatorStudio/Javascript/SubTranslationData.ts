interface ISubTranslationData {
    IndexReference: number[];
    CurrentReference: KnockoutComputed<number>;

    CurrentIndex: KnockoutObservable<number>;
    MaxIndex: KnockoutComputed<number>;

    NumberOfLines: KnockoutComputed<number>;
}

class SubTranslationData implements ISubTranslationData {
    IndexReference: number[];
    CurrentReference: KnockoutComputed<number>;

    CurrentIndex: KnockoutObservable<number>;
    MaxIndex: KnockoutComputed<number>;

    NumberOfLines: KnockoutComputed<number>;

    constructor(conditionList: boolean[]) {
        if (conditionList == undefined) throw Error("Condition List passed is invalid. Cannot construct Sub Translation Data");

        this.IndexReference = [];

        for (var i = 0; i < conditionList.length; i++) {
            if (conditionList[i]) this.IndexReference.push(i);
        }

        if (this.IndexReference.length == 0) throw Error("Condition List returned no results. Cannot construct Sub Translation Data");

        this.CurrentIndex = ko.observable(0);
        this.MaxIndex = ko.computed({
            owner: this,
            read: () => {
                return this.IndexReference.length - 1;
            }
        });

        this.NumberOfLines = ko.computed({
            owner: this,
            read: () => {
                return this.IndexReference.length;
            }
        });

        this.CurrentReference = ko.computed({
            owner: this,
            read: () => {
                return this.IndexReference[this.CurrentIndex()];
            }
        });
    }
}