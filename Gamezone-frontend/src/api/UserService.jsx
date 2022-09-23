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
}
