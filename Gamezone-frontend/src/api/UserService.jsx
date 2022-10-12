import request from "./request";

export default class UserService {
  static async Login(data) {
    return await request({
      url: `/users/login`,
      method: "POST",
      data: data,
    });
  }

  static async Register(data) {
    return await request({
      url: `/users`,
      method: "POST",
      data: data,
    });
  }

  static async GetUserByUsername(username) {
    return await request({
      url: `/users/username/${username}`,
      method: "GET",
    });
  }

  static async getGenresPaginated(page, searchString) {
    return await request({
      url: `/users/page/${page}/page-size/${9}?searchString=${searchString}`,
      method: "GET",
    });
  }

  static async AddGameToFavorite(userid, gameid) {
    return await request({
      url: `/users/${userid}/games/${gameid}`,
      method: "POST",
    });
  }

  static async RemoveGameFromFavorite(userid, gameid) {
    return await request({
      url: `/users/${userid}/games/${gameid}`,
      method: "DELETE",
    });
  }

  static async GetUsersFavorites(username) {
    return await request({
      url: `/users/favorite-games/${username}`,
      method: "GET",
    });
  }

  static async GetUserReviews(username) {
    return await request({
      url: `/users/reviews/${username}`,
      method: "GET",
    });
  }

  static async ChangePassword(data) {
    return await request({
      url: `/users/change-password`,
      method: "POST",
      data: data,
    });
  }

  static async DeleteUser(id) {
    return await request({
      url: `/users/${id}`,
      method: "DELETE",
    });
  }

  static async GetUsers(id) {
    return await request({
      url: "/users",
      method: "GET",
    });
  }

  static async AddRoleToUser(username, rolename) {
    return await request({
      url: `/users/assign-role/user/${username}/role/${rolename}`,
      method: "POST",
    });
  }

  static async RemoveRoleFromUser(username, rolename) {
    return await request({
      url: `/users/assign-role/user/${username}/role/${rolename}`,
      method: "DELETE",
    });
  }

  static async updateUserProfileImage(data) {
    return await request({
      url: `/users`,
      method: "PATCH",
      data: [
        {
          operationType: 0,
          path: "profileImageSrc",
          op: "replace",
          from: `${data.from}`,
          value: `${data.value}`,
        },
      ],
      config: {
        headers: {
          Accept: "*/*",
          "Content-Type": "application/json-patch+json",
        },
      },
    });
  }

  static async UsersAutoComplete(searchstring) {
    return await request({
      url: `/users/auto-complete/${searchstring}`,
      method: "GET",
    });
  }
}
