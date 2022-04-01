const { Schema, model } = require('mongoose');

const commentSchema = new Schema({
    comment: {
        type: String,
        required: true,
        trim: true,
    },
    postDate: {
        type: Date,
        required: true,
    },
    post: {
        type: Schema.Types.ObjectId,
        ref: 'Post'
    },
    user: {
        type: Schema.Types.ObjectId,
        ref:'User',
    }
})

const Comment = model('Event', commentSchema);

module.exports = Comment;