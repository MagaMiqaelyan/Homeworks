using System;
using System.Collections;
using System.Collections.Generic;

namespace ProofOfWork
{
    public class Blockchain
    {
        public IList<Block> Chain { get; set; }
        public int Difficulty { get; set; }

        /// <summary>
        /// Initializing
        /// </summary>
        public Blockchain()
        {
            Difficulty = 2;
            InitializeChain();
            AddGenesisBlock();
        }

        /// <summary>
        /// Initializing chain
        /// </summary>
        public void InitializeChain()
        {
            Chain = new List<Block>();
        }

        /// <summary>
        /// Add that block to a chain
        /// </summary>
        /// <param name="block"></param>
        public void AddBlock(Block block)
        {
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Mine(this.Difficulty);
            Chain.Add(block);
        }

        /// <summary>
        /// Add first block to a chain
        /// </summary>
        public void AddGenesisBlock()
        {
            Chain.Add(CreateGenesisBlock());
        }

        /// <summary>
        /// Create first block
        /// </summary>
        public Block CreateGenesisBlock()
        {
            return new Block(DateTime.Now, null, "{}");
        }

        /// <summary>
        /// Get last block 
        /// </summary>
        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }
               
    }
}
