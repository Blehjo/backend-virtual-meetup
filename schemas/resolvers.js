const { gql } = require("apollo-server-express");

const typeDefs = gql`
  scalar Date
  type User {
    _id: ID!
    email: String!
    password: String!
    profile: Profile
  }

  type Profile {
    _id: ID!
    firstName: String!
    lastName: String!
    gender: String!
    photo: String
    bio: String!
    birthdate: Date!
    currentCity: String!
    platforms: String!
    user: User
  }
  input ProfileInput {
    profileId: String!
    firstName: String
    lastName: String
    gender: String
    photo: String
    bio: String
    birthdate: Date
    currentCity: String
    platforms: String
  }

  type Group {
    _id: ID!
    groupName: String!
    description: String!
    event: Event
    profile: Profile
    user: User
  }
  input GroupInput {
    groupId: String
    groupName: String
    description: String
  }

  type Event {
    _id: ID!
    eventName: String!
    eventDate: Date!
    lobbyCode: String
    description: String!
    group: Group
  }

  type Post {
    _id: ID!
    title: String!
    content: String!
    date: Date!
    user: User
    comment: Comment
  }
  
  type Comment {
    _id: ID!
    comment: String!
    commentDate: Date!
    post: Post
    user: User
  }

  type Auth {
    token: ID!
    user: User
  }

  type Query {
    users: [User]
    user(id: ID!): User
    profiles: [Profile]
    profile(id: ID!): Profile
    userprofile(user:ID!): Profile
    groupsTest: [Group]
    groups(user: ID!): [Group]
    groups(event: ID!): [Group]
    eventTest: [Event]
    event(id: ID!): Event
    event(group: ID!): Event
    postTest: [Post]
    posts(user: ID!): [Post]
    posts(event: ID!): [Post]
    comments(post: ID!): [Comment]
    me: User
  }

  type Mutation {
    login(email: String!, password: String!): Auth
    addUser(email: String!, password: String!): Auth
    updateUser(id: ID!, profile: ID!): User
    addProfile(
      firstName: String!
      lastName: String!
      gender: String!
      photo: String
      bio: String!
      birthdate: Date!
      currentCity: String!
      platforms: String!
      user: ID
    ): Profile
    updateProfile(
      profileID: ID!
      firstName: String
      lastName: String
      gender: String
      photo: String
      bio: String
      birthdate: Date
      currentCity: String
      platforms: String
    ): Profile
    removeProfile(profileId: ID!): Profile
    addGroup(
      groupName: String!
      description: String!
      event: ID
      profile: ID
      user: ID
    ): Group
    updateGroup(
      groupID: ID!
      groupName: String
      description: String
    ): Group
    removeGroup(groupId: ID!): Group
    addEvent(
      eventName: String!
      eventDate: Date!
      lobbyCode: String
      description: String!
      group: ID
    ): Event
    updateEvent(
      eventID: ID!
      eventName: String
      eventDate: Date
      lobbyCode: String
      description: String
    ): Event
    removeEvent(eventId: ID!): Event
    addPost(
      title: String!
      content: String!
      date: Date!
      user: ID
    ): Post
    updatePost(
      postID: ID!
      title: String
      content: String
    ): Post
    removePost(postID: ID!): Post
    addComment(
      comment: String!
      commentDate: Date!
      post: ID
      user: ID
    ): Comment
    updateComment(
      commentID: ID!
      comment: String
    ): Comment
    removeComment(commentID: ID!): Comment
  }
`;

module.exports = typeDefs;
