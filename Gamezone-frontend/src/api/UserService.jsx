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

  static async GetUserByUsername(username){
    return await request({
      url: `/users/username/${username}`,
      method: "GET",
    });
  }

  static async AddGameToFavorite(userid, gameid){
    return await request({
      url: `/users/${userid}/games/${gameid}`,
      method: "POST",
    });
  }

  static async RemoveGameFromFavorite(userid, gameid){
    return await request({
      url: `/users/${userid}/games/${gameid}`,
      method: "DELETE",
    });
  }

  static async GetUsersFavorites(id){
    return await request({
      url: `/users/favorite-games/${id}`,
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
}
