import React from "react";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import moment from "moment";
import axios from "axios";
import MoreMenu from "../Menus/MoreMenu";
import { convertUTCDateToLocalDate } from "../../utils/TimeConverting";
import { Link } from "react-router-dom";
import { Typography } from "@mui/material";
import { useUser } from "../../hooks/useUser";
import ReplyService from "../../api/ReplyService";

function Reply(props) {
  const { user } = useUser();
  
  const handleDelete = async () => {
    ReplyService.deleteReply(props.reply.id, user.Id)
      .then((response) => {
        props.getReplies();
      })
      .catch((err) => console.log(err));
  };

  return (
    <div style={{ padding: 14 }} className="App">
      <Grid container wrap="nowrap" spacing={2}>
        <Grid item>
          <Avatar alt="Remy Sharp" src={props.reply.userProfileImage} />
        </Grid>
        <Grid justifyContent="left" item xs zeroMinWidth>
          <Link
            style={{ textDecoration: "none", color: "inherit" }}
            to={`/profile/${props.reply.userName}/reviews`}
          >
            <Typography
              sx={{
                margin: 0,
                textAlign: "left",
                fontWeight: "bold",
                cursor: "pointer",
                "&:hover": {
                  color: "primary.main",
                },
              }}
            >
              {props.reply.userName}
            </Typography>
          </Link>
          <p style={{ textAlign: "left" }}>{props.reply.content}</p>
          <p style={{ textAlign: "left", color: "gray" }}>
            {moment(
              convertUTCDateToLocalDate(new Date(props.reply.createdAt))
            ).fromNow()}
          </p>
        </Grid>
        <Grid>
          {(user.UserName === props.reply.userName || user.IsAdmin) && (
            <MoreMenu handleDelete={handleDelete} />
          )}
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </div>
  );
}

export default Reply;
