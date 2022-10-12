import request from "./request";

export default class CommentService {
  static async deleteComment(id, userid) {
    return await request({
      url: `/comments/${id}/user/${userid}`,
      method: "DELETE",
    });
  }

  static async postComment(data) {
    return await request({
      url: "/comments",
      method: "POST",
      data: data,
    });
  }
}
