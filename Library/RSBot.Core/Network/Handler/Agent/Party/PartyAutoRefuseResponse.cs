﻿using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Party
{
    internal class PartyAutoRefuseResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB067;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            if (Core.Game.Party.HasPendingRequest)
                Core.Game.AcceptanceRequest = null;

            EventManager.FireEvent("OnPartyRequestRefused");
        }
    }
}