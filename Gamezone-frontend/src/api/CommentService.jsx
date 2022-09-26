import request from "./request";

export default class CommentService {

  static async deleteComment(id) {
    return await request({
      url: `/comments/${id}`,
      method: "DELETE",
    });
  }
}
