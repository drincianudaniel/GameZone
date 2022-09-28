import request from "./request";

export default class ReplyService {

  static async deleteReply(id, userid) {
    return await request({
      url: `/replies/${id}/user/${userid}`,
      method: "DELETE",
    });
  }

  static async postReply(data){
    return await request({
      url: "/replies",
      method: "POST",
      data: data
    });
  }

}
