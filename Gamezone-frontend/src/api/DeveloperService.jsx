import request from "./request";

export default class DeveloperService {
  static async getDevelopersPaginated(page) {
    return await request({
      url: `/developers/page/${page}/page-size/${10}`,
      method: "GET",
    });
  }

  static async deleteDeveloper(id) {
    return await request({
      url: `/developers/${id}`,
      method: "DELETE",
    });
  }

}
