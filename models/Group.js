const { Schema, model } = require('mongoose');

const groupSchema = new Schema({
    groupName: {
        type: String,
        required: true,
    },
    description: {
        type: String,
        required: true,
    },
    event: {
        type: Schema.Types.ObjectId,
        ref:'Event'
    },
    profile: {
        type: Schema.Types.ObjectId,
        ref: 'Profile',
    },
    user: {
        type: Schema.Types.ObjectId,
        ref: 'User',
    },
})

const Group = model('Group', groupSchema);

module.exports = Group;