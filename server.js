const http = require("http");
const express = require("express");
const socketio = require("socket.io");
const randomColor = require("randomcolor");
const createBoard = require("./create-board");
const createCooldown = require("./create-cooldown");

const app = express();

//call the initiate file in client folder
app.use(express.static(`${__dirname}/../client`));

const server = http.createServer(app);
const io = socketio(server);

const socketStatus = {};
const { clear, getBoard, makeTurn } = createBoard(20);

//On connection event handler
io.on("connection", (sock) => {
  const socketId = socket.id;
  socketsStatus[socket.id] = {};

  const color = randomColor();
  const cooldown = createCooldown(2000);

  //Push board to client page
  sock.emit("board", getBoard());

  //Handle Inputed Text in Chat
  sock.on("message", (text) => io.emit("message", text));

  sock.on("turn", ({ x, y }) => {
    if (cooldown()) {
      const playerWon = makeTurn(x, y, color);
      io.emit("turn", { x, y, color });

      if (playerWon) {
        sock.emit("message", "You Won!");
        io.emit("message", "New Round");
        clear();
        io.emit("board");
      }
    }
  });

  //Voice Chat Event Handler
  socket.on("voice", function (data) {
    var newData = data.split(";");
    newData[0] = "data:audio/ogg;";
    newData = newData[0] + newData[1];

    for (const id in socketsStatus) {
      if (id != socketId && !socketsStatus[id].mute && socketsStatus[id].online)
        socket.broadcast.to(id).emit("send", newData);
    }
  });

  socket.on("voiceChatState", function (data) {
    socketsStatus[socketId] = data;

    io.sockets.emit("usersUpdate", socketsStatus);
  });

  socket.on("disconnect", function () {
    delete socketsStatus[socketId];
  });
});

server.on("error", (err) => {
  console.error(err);
});

server.listen(8080, () => {
  console.log("server is ready");
});
