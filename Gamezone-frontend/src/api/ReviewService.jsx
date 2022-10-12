import request from "./request";

export default class ReviewService {
  static async deleteReview(id, userid) {
    return await request({
      url: `/reviews/${id}/user/${userid}`,
      method: "DELETE",
    });
  }

  static async postReview(data) {
    return await request({
      url: "/reviews",
      method: "POST",
      data: data,
    });
  }
}
