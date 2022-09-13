import { Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import PostReplyForm from "../Forms/PostReplyForm";
import GamePagination from "../Pagination/GamePagination";
import Reply from "./Reply";

function Replies(props) {
  const [replies, setReplies] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);

  useEffect(() => {
    getReplies();
  }, [page]);

  const getReplies = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/replies/comment/${
          props.commentId
        }/page/${page}/page-size/${4}`
      )
      .then((res) => {
        setReplies(res.data.data);
        setNumberOfPages(res.data.totalPages);
        console.log(res.data);
      });
  };

  return (
    <div>
      {replies.length > 0 ? replies.map((reply) => {
        return (
          <div>
            <Reply key={reply.id} reply={reply} getReplies={getReplies} />
          </div>
        );
      }): <Typography sx={{marginBottom: 2}}>No replies yet. Please add a reply.</Typography>}
      <PostReplyForm commentId={props.commentId} getReplies={getReplies} />
      <GamePagination setPage={setPage} numberOfPages={numberOfPages}/>
    </div>
  );
}

export default Replies;
