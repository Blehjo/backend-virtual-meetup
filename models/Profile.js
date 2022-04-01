const { Schema, model } = require('mongoose');

const profileSchema = new Schema({
    firstName: {
      type: String,
      required: true,
      trim: true,
    },
    lastName: {
      type: String,
      required: true,
      trim: true,
    },
    gender: {
        type: String,
        required: true,
    },
    photo: {
        type: String,
    },
    bio: {
        type: String,
        required: true,
    },
    birthdate: {
        type: Date,
        required: true,
    },
    currentCity: {
        type: String,
        required: true,
    },
    platforms: {
        type: String,
        required: true,
    },
    user:{
        type:Schema.Types.ObjectId,
        ref:'User'
    }
})

const Profile = model('Profile', profileSchema);

module.exports = Profile;