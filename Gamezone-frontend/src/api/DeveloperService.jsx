import request from "./request";

export default class DeveloperService {

  static async getDevelopers(){
    return await request({
      url: "/developers",
      method: "GET",
    });
  }

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

  static async postDeveloper(data){
    return await request({
      url: "/developers",
      method: "POST",
      data: data
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
