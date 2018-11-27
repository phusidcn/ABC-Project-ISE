var mongoose = require("mongoose");
var Schema = mongoose.Schema;

var SoGDchema = new Schema({
  id: { type: "String", required: true },
  ghiChu: { type: "String"},
  soTien: { type: "Number", required: true },
  viID: {type: "String", required: true},
  ngaythuchien: {type: "String"},
  nhom: {type: "String"}
});

var SoGD = mongoose.model("SoGD", SoGDSchema);

module.exports = SoGD;
