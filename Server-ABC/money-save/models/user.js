var mongoose = require("mongoose");
var Schema = mongoose.Schema;

var UserSchema = new Schema({
  id: { type: "String", required: true },
  email: { type: "String", required: true },
  name: { type: "String", required: true },
  dob: { type: "String", required: true },
  viID: {type: "String", require: true},
  soTietKiemID: {type: "String", required: true}
});

var User = mongoose.model("User", UserSchema);

module.exports = User;
