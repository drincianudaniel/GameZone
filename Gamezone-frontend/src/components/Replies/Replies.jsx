import { Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { useUser } from "../../hooks/useUser";
import PostReplyForm from "../Forms/PostReplyForm";
import GamePagination from "../Pagination/GamePagination";
import Reply from "./Reply";

function Replies(props) {
  const [replies, setReplies] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);
  const { user } = useUser();
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

  useEffect(() => {
    getReplies();

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page]);

  return (
    <div>
      {replies.length > 0 ? (
        replies.map((reply) => {
          return (
            <div>
              <Reply key={reply.id} reply={reply} getReplies={getReplies} />
            </div>
          );
        })
      ) : (
        <Typography sx={{ marginBottom: 2 }}>
          No replies yet. Please add a reply.
        </Typography>
      )}

      {user.IsLoggedIn && (
        <PostReplyForm commentId={props.commentId} getReplies={getReplies} />
      )}
      {!user.IsLoggedIn && (
        <Typography sx={{ mb: 2 }}>
          You have to be{" "}
          <Link to={"/login"}>
            <Typography sx={{ display: "inline", color: "primary.main" }}>
              logged in
            </Typography>
          </Link>{" "}
          to post a reply.
        </Typography>
      )}

      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </div>
  );
}

export default Replies;
