import React from "react";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import moment from "moment";
import axios from "axios";
import MoreMenu from "../Menus/MoreMenu";
import { convertUTCDateToLocalDate } from "../../utils/TimeConverting";
import { Link } from "react-router-dom";
import { Box, Typography } from "@mui/material";
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
    <Box>
      <Grid container wrap="nowrap" spacing={2}>
        <Grid item>
          <Avatar alt="Remy Sharp" src={props.reply.userProfileImage} />
        </Grid>
        <Grid justifyContent="left" item xs zeroMinWidth>
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
            }}
          >
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
            <Typography
              sx={{ fontSize: 15, textAlign: "left", color: "gray", ml: 1 }}
            >
              {moment(
                convertUTCDateToLocalDate(new Date(props.reply.createdAt))
              ).fromNow()}
            </Typography>
          </Box>
          <Typography sx={{ textAlign: "left", mt: 1 }}>
            {props.reply.content}
          </Typography>
        </Grid>
        <Grid>
          {(user.UserName === props.reply.userName || user.IsAdmin) && (
            <MoreMenu handleDelete={handleDelete} />
          )}
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </Box>
  );
}

export default Reply;
