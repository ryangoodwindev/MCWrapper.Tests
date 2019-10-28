using MCWrapper.CLI.Connection;
using MCWrapper.Data.Models.Blockchain;
using MCWrapper.Factory;
using MCWrapper.RPC.Connection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MCWrapper.Tests
{
    [TestFixture]
    public class GetBlockchainInfoTests
    {
        private MCWrapperClientFactory ClientFactory;

        [SetUp]
        public void Startup() => 
            ClientFactory = ServiceHelper.GetService<MCWrapperClientFactory>();

        [Test]
        public async Task GetBlockchainInfoTest()
        {
            // Act - Request Blockchain information object
            var rpcResponse = await ClientFactory.RpcClients
                .GetBlockchainRpcClient().GetBlockchainInfoAsync();

            var cliResponse = await ClientFactory.CliClients
                .GetBlockchainClient().GetBlockchainInfoAsync();

            // Assert (Type and null assertions)
            Assert.IsInstanceOf(typeof(RpcResponse<GetBlockchainInfoResult>), rpcResponse);
            Assert.IsNull(rpcResponse.Error);
            Assert.IsNotNull(rpcResponse.Result);

            Assert.IsInstanceOf(typeof(CliResponse<GetBlockchainInfoResult>), cliResponse);
            Assert.IsEmpty(cliResponse.Error);
            Assert.IsNotNull(cliResponse.Result);

            // Assert RPC result (Object property assertions)
            var rpcResult = rpcResponse.Result;

            Assert.IsNotEmpty(rpcResult.BestBlockHash);
            Assert.GreaterOrEqual(rpcResult.Blocks, 59);
            Assert.IsNotEmpty(rpcResult.Chain);
            Assert.IsNotEmpty(rpcResult.ChainName);
            Assert.IsInstanceOf<int>(rpcResult.ChainRewards);
            Assert.IsNotEmpty(rpcResult.Chainwork);
            Assert.IsNotEmpty(rpcResult.Description);
            Assert.IsInstanceOf<float>(rpcResult.Difficulty);
            Assert.IsInstanceOf<int>(rpcResult.Headers);
            Assert.IsNotEmpty(rpcResult.Protocol);
            Assert.False(rpcResult.ReIndex);
            Assert.IsInstanceOf<int>(rpcResult.SetupBlocks);
            Assert.IsInstanceOf<int>(rpcResult.VerificationProgress);

            // Assert CLI result (Object property assertions)
            var cliResult = cliResponse.Result;

            Assert.IsNotEmpty(cliResult.BestBlockHash);
            Assert.GreaterOrEqual(cliResult.Blocks, 59);
            Assert.IsNotEmpty(cliResult.Chain);
            Assert.IsNotEmpty(cliResult.ChainName);
            Assert.IsInstanceOf<int>(cliResult.ChainRewards);
            Assert.IsNotEmpty(cliResult.Chainwork);
            Assert.IsNotEmpty(cliResult.Description);
            Assert.IsInstanceOf<float>(cliResult.Difficulty);
            Assert.IsInstanceOf<int>(cliResult.Headers);
            Assert.IsNotEmpty(cliResult.Protocol);
            Assert.False(cliResult.ReIndex);
            Assert.IsInstanceOf<int>(cliResult.SetupBlocks);
            Assert.IsInstanceOf<int>(cliResult.VerificationProgress);
        }
    }
}
