import request from "./request";

export default class PlatformService {
  static async getPlatformsPaginated(page, searchString) {
    return await request({
      url: `/platforms/page/${page}/page-size/${9}?searchString=${searchString}`,
      method: "GET",
    });
  }

  static async deletePlatform(id) {
    return await request({
      url: `/platforms/${id}`,
      method: "DELETE",
    });
  }

  static async updatePlatform(id, data) {
    return await request({
      method: "PUT",
      url: `/platforms/${id}`,
      data: data,
      config: { headers: {
        'Accept': '*/*',
        'Content-Type': 'application/json-patch+json'
      }},
    });
  }

}
