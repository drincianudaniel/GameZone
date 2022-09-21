import request from "./request";

export default class DeveloperService {
  static async getDevelopersPaginated(page, searchString) {
    return await request({
      url: `/developers/page/${page}/page-size/${9}?searchString=${searchString}`,
      method: "GET",
    });
  }

  static async deleteDeveloper(id) {
    return await request({
      url: `/developers/${id}`,
      method: "DELETE",
    });
  }

  static async updateDeveloper(id, data) {
    return await request({
      method: "PUT",
      url: `/developers/${id}`,
      data: data,
      config: { headers: {
        'Accept': '*/*',
        'Content-Type': 'application/json-patch+json'
      }},
    });
  }
}
