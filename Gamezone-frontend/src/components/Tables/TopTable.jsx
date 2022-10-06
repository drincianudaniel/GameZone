import * as React from "react";
import { styled } from "@mui/material/styles";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { Link } from "react-router-dom";
import StarOutlinedIcon from "@mui/icons-material/StarOutlined";
import moment from "moment";

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));

export default function TopTable(props) {
  return (
    <TableContainer className="gameTable" component={Paper}>
      <Table aria-label="customized table">
        <TableHead>
          <TableRow>
            <StyledTableCell align="center">Rank</StyledTableCell>
            <StyledTableCell align="center">Name</StyledTableCell>
            <StyledTableCell align="center">Rating</StyledTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {props.games.map((game, value) => (
            <StyledTableRow key={game.name}>
              <StyledTableCell align="center">
                <Typography
                  sx={{ fontSize: 50, color: "#888", fontWeight: "bold" }}
                >
                  {(props.page === 1 ? 0 : (props.page - 1) * 10) + value + 1}
                </Typography>
              </StyledTableCell>
              <StyledTableCell component="th" scope="row">
                <Grid container spacing={2}>
                  {" "}
                  <Grid item md={1}>
                    <Link
                      to={`/game/${game.id}/comments`}
                      style={{ textDecoration: "none" }}
                    >
                      <Box
                        component="img"
                        src={game.imageSrc}
                        sx={{
                          height: 100,
                          width: 75,
                          objectFit: "cover",
                        }}
                      />
                    </Link>
                  </Grid>
                  <Grid item md={4}>
                    <Box
                      sx={{
                        height: "100%",
                        display: "flex",
                        alignItems: "center",
                      }}
                    >
                      <Link
                        to={`/game/${game.id}/comments`}
                        style={{ textDecoration: "none" }}
                      >
                        <Typography sx={{ fontSize: 20, color: "#1c439b" }}>
                          {game.name}
                        </Typography>
                        <Typography sx={{ fontSize: 15, color: "black" }}>
                          {moment(game.releaseDate).format("MMMM Do YYYY")}
                        </Typography>
                      </Link>
                    </Box>
                  </Grid>
                </Grid>
              </StyledTableCell>
              <StyledTableCell align="center">
                <Box
                  sx={{
                    height: "100%",
                    display: "flex",
                    alignItems: "center",
                    justifyContent: "center",
                  }}
                >
                  <StarOutlinedIcon
                    fontSize="medium"
                    stroke="orange"
                    strokeWidth={1}
                    sx={{ color: "#ffea00", marginRight: 1 }}
                  ></StarOutlinedIcon>
                  <Typography sx={{ fontSize: 15 }}>
                    {Math.round(game.totalRating * 10) / 10}/10
                  </Typography>
                </Box>
              </StyledTableCell>
            </StyledTableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
