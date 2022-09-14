import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import GamePagination from "../Pagination/GamePagination";
import Comment from "./Comment";
import PostCommentForm from "../Forms/PostCommentForm";
import { Typography } from "@mui/material";
function Comments() {
  const [comments, setComments] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);
  const params = useParams();

  useEffect(() => {
    getComments();

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page]);

  const getComments = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/comments/game/${
          params.id
        }/page/${page}/page-size/${4}`
      )
      .then((res) => {
        setComments(res.data.data);
        setNumberOfPages(res.data.totalPages);
        console.log(res.data);
      });
  };

  return (
    <div>
      {comments.length > 0 ? (
        comments.map((comment) => {
          return (
            <Comment
              key={comment.id}
              comment={comment}
              getComments={getComments}
            />
          );
        })
      ) : (
        <Typography sx={{ marginBottom: 2 }}>
          No comments yet. Please add a comment.
        </Typography>
      )}
      <PostCommentForm id={params.id} getComments={getComments} />
      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </div>
  );
}

export default Comments;
