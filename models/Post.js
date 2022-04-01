const { Schema, model } = require('mongoose');

const postSchema = new Schema({
    title: {
        type: String,
        require: true,
    },
    content: {
       type: String,
       require: true, 
    },
    date: {
        type: Date,
        require: true,
        default: Date.now,
    },
    user: {
        type: Schema.Types.ObjectId,
        ref: 'User'
    },
    comments: [
        {
            type: Schema.Types.ObjectId,
            ref: 'Comment'
        }
    ],
})

const Post = model('Post', postSchema);

module.exports = Post;