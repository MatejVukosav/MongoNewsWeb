//kad god naidemo na komentar brojimo po 1
var map = function () {
    if (this.comment !== undefined) {
        var count = 0;
        this.comment.forEach(function (comment) {
            count += 1;
        });
        emit(this._id, count);
    }
};

//sve vrijednosti koje je map izbacio dolaze tu pa ih zbrajam
var reduce = function (key, values) {
    var rv = {
        comment: key,
        count: 0
    };
    values.forEach(function (value) {
        rv.count += value.count;
    });
    return rv;
};

db.articles.mapReduce(
	map,
	reduce,
	{ out: "mr_comment" });

db.mr_comment.find().sort({ value: -1 })
db.articles.find({ comment: { $exists: true } }, { picture: 0, text: 0, headline: 0 }).pretty();