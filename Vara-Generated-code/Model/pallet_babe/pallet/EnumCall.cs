//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_babe.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> report_equivocation
        /// See [`Pallet::report_equivocation`].
        /// </summary>
        report_equivocation = 0,
        
        /// <summary>
        /// >> report_equivocation_unsigned
        /// See [`Pallet::report_equivocation_unsigned`].
        /// </summary>
        report_equivocation_unsigned = 1,
        
        /// <summary>
        /// >> plan_config_change
        /// See [`Pallet::plan_config_change`].
        /// </summary>
        plan_config_change = 2,
    }
    
    /// <summary>
    /// >> 70 - Variant[pallet_babe.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substrate.Vara.NET.NetApiExt.Generated.Model.sp_consensus_slots.EquivocationProof, Substrate.Vara.NET.NetApiExt.Generated.Model.sp_session.MembershipProof>, BaseTuple<Substrate.Vara.NET.NetApiExt.Generated.Model.sp_consensus_slots.EquivocationProof, Substrate.Vara.NET.NetApiExt.Generated.Model.sp_session.MembershipProof>, Substrate.Vara.NET.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumNextConfigDescriptor>
    {
    }
}
