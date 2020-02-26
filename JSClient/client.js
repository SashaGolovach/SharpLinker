const grpc = require("grpc");
const protoLoader = require("@grpc/proto-loader");

const PROTO_PATH = "greet.proto";
const SERVER_URI = "127.0.0.1:5000";

const packageDefinition = protoLoader.loadSync(PROTO_PATH);
const protoDescriptor = grpc.loadPackageDefinition(packageDefinition);
const client = new protoDescriptor.greet.Greeter(
  SERVER_URI,
  grpc.credentials.createInsecure()
);

debugger;

client.SayHello({ name: `Sasha` }, (error, response) => {
  if (error) {
    console.error(error);
  }
  console.log("response ", response);
});

const call = client.SayDoubleHello({ name: "Mark" });

call.on("data", function(data) {
  console.log(data);
});
