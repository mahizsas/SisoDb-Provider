﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SisoDb.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SisoDb.Resources.ExceptionMessages", typeof(ExceptionMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Item of type &apos;{0}&apos; has no Id member specified. A Guid or Int property named &apos;Id&apos; was expected..
        /// </summary>
        public static string AutoSchemaBuilder_MissingIdMember {
            get {
                return ResourceManager.GetString("AutoSchemaBuilder_MissingIdMember", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Item of type &apos;{0}&apos; has no Id member specified. A Guid or Int property named &apos;Id&apos; was expected..
        /// </summary>
        public static string AutoSchemaBuilder_MissingIdMember1 {
            get {
                return ResourceManager.GetString("AutoSchemaBuilder_MissingIdMember1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Item of type &apos;{0}&apos; has no members that are indexable. There&apos;s no point in storing items that has nothing to index..
        /// </summary>
        public static string AutoSchemaBuilder_MissingIndexableMembers {
            get {
                return ResourceManager.GetString("AutoSchemaBuilder_MissingIndexableMembers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Item of type &apos;{0}&apos; has no members that are indexable. There&apos;s no point in treating items that has nothing to index..
        /// </summary>
        public static string AutoSchemaBuilder_MissingIndexableMembers1 {
            get {
                return ResourceManager.GetString("AutoSchemaBuilder_MissingIndexableMembers1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The id property: &apos;{0}&apos;; is not of suported type. Only Guid and Int is accepted..
        /// </summary>
        public static string AutoSchemaBuilder_UnsupportedIdAccessorType {
            get {
                return ResourceManager.GetString("AutoSchemaBuilder_UnsupportedIdAccessorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not clear all structure set cache entries. See contained exceptions for more info..
        /// </summary>
        public static string CacheProvider_Clear_failed {
            get {
                return ResourceManager.GetString("CacheProvider_Clear_failed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not update structure, since it has a Concurrency token member, with a value not equal to the one in store..
        /// </summary>
        public static string ConcurrencyException {
            get {
                return ResourceManager.GetString("ConcurrencyException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type of the Concurrency token member &apos;{0}&apos; should be a Guid, Int, or Long..
        /// </summary>
        public static string ConcurrencyTokenAccessor_Invalid_Type {
            get {
                return ResourceManager.GetString("ConcurrencyTokenAccessor_Invalid_Type", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Concurrency token member &apos;{0}&apos; must lie on the root object..
        /// </summary>
        public static string ConcurrencyTokenAccessor_InvalidLevel {
            get {
                return ResourceManager.GetString("ConcurrencyTokenAccessor_InvalidLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The ConcurrencyToken member should be either: Guid, Int or Long..
        /// </summary>
        public static string ConcurrencyTokenIsOfWrongType {
            get {
                return ResourceManager.GetString("ConcurrencyTokenIsOfWrongType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not parse sent connection string. If connection string name is passed. Ensure it has match in config-file. Inspect inner exception for more details..
        /// </summary>
        public static string ConnectionInfo_CouldNotFormatDbConnectionString {
            get {
                return ResourceManager.GetString("ConnectionInfo_CouldNotFormatDbConnectionString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not parse sent server connection string. If connection string name is passed. Ensure it has match in config-file. Inspect inner exception for more details..
        /// </summary>
        public static string ConnectionInfo_CouldNotFormatServerConnectionString {
            get {
                return ResourceManager.GetString("ConnectionInfo_CouldNotFormatServerConnectionString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not locate a connection string. If connection string name is passed. Ensure it has match in config-file..
        /// </summary>
        public static string ConnectionInfo_CouldNotLocateConnectionString {
            get {
                return ResourceManager.GetString("ConnectionInfo_CouldNotLocateConnectionString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The name of the database could not be extracted from the connection-info..
        /// </summary>
        public static string ConnectionInfo_MissingName {
            get {
                return ResourceManager.GetString("ConnectionInfo_MissingName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The DbClient instance has allready been disposed..
        /// </summary>
        public static string DbClient_ObjectAllreadyDisposed {
            get {
                return ResourceManager.GetString("DbClient_ObjectAllreadyDisposed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Don&apos;t know how to translate the type &apos;{0}&apos; to a DbType. Send us a pull request..
        /// </summary>
        public static string DbDataTypeTranslator_UnsupportedType {
            get {
                return ResourceManager.GetString("DbDataTypeTranslator_UnsupportedType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The query should only return StructureIds which alows onle WHERE expressions. Take, Paging and Sorting etc is not allowed..
        /// </summary>
        public static string DbQueryGenerator_OnlyWhereExpressionsAreAllowed {
            get {
                return ResourceManager.GetString("DbQueryGenerator_OnlyWhereExpressionsAreAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The StructureNamePrefix is to long. Max len is {0} chars..
        /// </summary>
        public static string DbSchemaNamingPolicy_StructureNamePrefix_IsToLong {
            get {
                return ResourceManager.GetString("DbSchemaNamingPolicy_StructureNamePrefix_IsToLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not generate lambda expression from sent string.\r\nCompiler info: {0}..
        /// </summary>
        public static string DynamicLambdaBuilder_Build_Error {
            get {
                return ResourceManager.GetString("DynamicLambdaBuilder_Build_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type &apos;{0}&apos; can not be used when building LambdaExpression from string, since no FullName could be extracted..
        /// </summary>
        public static string DynamicLambdaBuilder_Build_TypeFullNameMissing {
            get {
                return ResourceManager.GetString("DynamicLambdaBuilder_Build_TypeFullNameMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expression does not seem to be a lambda expression. It should start with e.g &apos;i =&gt; &apos;..
        /// </summary>
        public static string DynamicLambdaBuilder_InvalidExpressionFormat {
            get {
                return ResourceManager.GetString("DynamicLambdaBuilder_InvalidExpressionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Direct memberaccess of node: &apos;{0}&apos;; with with membertype: &apos;{1}&apos;; is not supported!.
        /// </summary>
        public static string ExpressionEvaluator_EvaluateMemberExpression_NotSupported {
            get {
                return ResourceManager.GetString("ExpressionEvaluator_EvaluateMemberExpression_NotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Sortings has allready been initialized..
        /// </summary>
        public static string GetCommand_SortingsAllreadyInitialized {
            get {
                return ResourceManager.GetString("GetCommand_SortingsAllreadyInitialized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type &apos;{0}&apos; is unsupported and a getter for the StructureId accessor can not be created..
        /// </summary>
        public static string Getter_Unsupported_type {
            get {
                return ResourceManager.GetString("Getter_Unsupported_type", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id values must lie on the root object..
        /// </summary>
        public static string IdAccessor_GetIdValue_InvalidLevel {
            get {
                return ResourceManager.GetString("IdAccessor_GetIdValue_InvalidLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Id members must lie on the root object..
        /// </summary>
        public static string IdAccessor_InvalidLevel {
            get {
                return ResourceManager.GetString("IdAccessor_InvalidLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Property.PropertyType &apos;{0}&apos; is not supported by the IdAccessor..
        /// </summary>
        public static string IdAccessor_UnsupportedPropertyType {
            get {
                return ResourceManager.GetString("IdAccessor_UnsupportedPropertyType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Property.PropertyType &apos;{0}&apos; is not supported by the IdAccessor. Supported types are: Guid, Nullable-Guid, Int32, Nullable-Int32, Int64 and Nullable-Int64..
        /// </summary>
        public static string IdAccessor_UnsupportedPropertyType1 {
            get {
                return ResourceManager.GetString("IdAccessor_UnsupportedPropertyType1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The include expression &apos;{0}&apos; does not target a member in the structure..
        /// </summary>
        public static string IncludeExpressionDoesNotTargetMember {
            get {
                return ResourceManager.GetString("IncludeExpressionDoesNotTargetMember", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An Index-instance must be provided with a name..
        /// </summary>
        public static string Index_IsMissingName {
            get {
                return ResourceManager.GetString("Index_IsMissingName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The operator type &apos;{0}&apos; can not be converted to &apos;IsNotNullOperatpr&apos; or &apos;NullOperator&apos;..
        /// </summary>
        public static string LambdaOperator_IsOrIsNot_NotSupported {
            get {
                return ResourceManager.GetString("LambdaOperator_IsOrIsNot_NotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operator &apos;{0}&apos; is not supported!.
        /// </summary>
        public static string LambdaOperator_OperatorTypeIsNotSupported {
            get {
                return ResourceManager.GetString("LambdaOperator_OperatorTypeIsNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not evaluate the method call: &apos;{0}&apos;.
        ///Specific supported method exists as extensionmethods and are prefixed with &apos;Qx&apos;. Import namespace &apos;SisoDb.Querying&apos; to enable them..
        /// </summary>
        public static string LambdaParser_UnsupportedMethodCall {
            get {
                return ResourceManager.GetString("LambdaParser_UnsupportedMethodCall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Conversion of values in expression is only allowed for nullable valuetypes..
        /// </summary>
        public static string LambdaParser_VisitUnary_InvalidConvert {
            get {
                return ResourceManager.GetString("LambdaParser_VisitUnary_InvalidConvert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The unary operator &apos;{0}&apos; is not supported..
        /// </summary>
        public static string LambdaParser_VisitUnary_NotSupported {
            get {
                return ResourceManager.GetString("LambdaParser_VisitUnary_NotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The order by expression &apos;{0}&apos; does not target a member in the structure..
        /// </summary>
        public static string OrderByExpressionDoesNotTargetMember {
            get {
                return ResourceManager.GetString("OrderByExpressionDoesNotTargetMember", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The only supported methods for marking sortings are Asc() and Desc()..
        /// </summary>
        public static string OrderByParser_UnsupportedMethodForSortingDirection {
            get {
                return ResourceManager.GetString("OrderByParser_UnsupportedMethodForSortingDirection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You cant apply Unique on a member that is not of a simple type e.g. (int, string, bool) etc..
        /// </summary>
        public static string Property_Ctor_UniqueOnNonSimpleType {
            get {
                return ResourceManager.GetString("Property_Ctor_UniqueOnNonSimpleType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Member node: &apos;{0}&apos;; Exact match of strings is only supported for String members and NOT Text members..
        /// </summary>
        public static string QxIsExactly_NotSupportedForTexts {
            get {
                return ResourceManager.GetString("QxIsExactly_NotSupportedForTexts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ReadOnceQueryable doesn&apos;t support yielding result. Use matching ToList method instead..
        /// </summary>
        public static string ReadOnceQueryable_YieldingNotSupported {
            get {
                return ResourceManager.GetString("ReadOnceQueryable_YieldingNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Session with id: &apos;{0}&apos;; against db: &apos;{1}&apos;; has allready been disposed..
        /// </summary>
        public static string Session_AllreadyDisposed {
            get {
                return ResourceManager.GetString("Session_AllreadyDisposed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Session with Id: &apos;{0}&apos;; against db &apos;{1}&apos;; is in a failed state and can/should not be used anymore..
        /// </summary>
        public static string Session_AlreadyFailed {
            get {
                return ResourceManager.GetString("Session_AlreadyFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type &apos;{0}&apos; is unsupported and a setter for the StructureId accessor can not be created..
        /// </summary>
        public static string Setter_Unsupported_type {
            get {
                return ResourceManager.GetString("Setter_Unsupported_type", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided StorageProvider &apos;{0}&apos; is not supported..
        /// </summary>
        public static string SisoDbFactory_UnknownStorageProvider {
            get {
                return ResourceManager.GetString("SisoDbFactory_UnknownStorageProvider", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provider: &apos;{0}&apos; does not support operation: {1}..
        /// </summary>
        public static string SisoDbNotSupportedByProviderException {
            get {
                return ResourceManager.GetString("SisoDbNotSupportedByProviderException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The SQLCE4 does not support individual string values longer than 4000chars..
        /// </summary>
        public static string SqlCe4_ToLongIndividualStringValue {
            get {
                return ResourceManager.GetString("SqlCe4_ToLongIndividualStringValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exceptions occured while releasing SqlCe4Connections from the pool..
        /// </summary>
        public static string SqlCe4ConnectionManager_ReleaseAllDbConnections {
            get {
                return ResourceManager.GetString("SqlCe4ConnectionManager_ReleaseAllDbConnections", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The database &apos;{0}&apos; doesn&apos;t exist..
        /// </summary>
        public static string SqlDatabase_InitializeExisting_DbDoesNotExist {
            get {
                return ResourceManager.GetString("SqlDatabase_InitializeExisting_DbDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not locate SQL for generating Structure-table for StructureId type: &apos;{0}&apos;..
        /// </summary>
        public static string SqlDbIndexesSchemaBuilder_GenerateSql {
            get {
                return ResourceManager.GetString("SqlDbIndexesSchemaBuilder_GenerateSql", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not locate SQL for generating Structure-table for StructureId type: &apos;{0}&apos;..
        /// </summary>
        public static string SqlDbStructureSchemaBuilder_GenerateSql {
            get {
                return ResourceManager.GetString("SqlDbStructureSchemaBuilder_GenerateSql", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not locate SQL for generating Structure-table for StructureId type: &apos;{0}&apos;..
        /// </summary>
        public static string SqlDbUniquesSchemaBuilder_GenerateSql {
            get {
                return ResourceManager.GetString("SqlDbUniquesSchemaBuilder_GenerateSql", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Max length of &apos;{0}&apos; exceeded with string value &apos;{1}&apos;..
        /// </summary>
        public static string SqlServerTableParams_ToLongString {
            get {
                return ResourceManager.GetString("SqlServerTableParams_ToLongString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicate Unique-index found for &apos;{0}&apos;.\r\nStructureId: &apos;{1}&apos;;Name: &apos;{2}&apos;;Value: &apos;{3}&apos;;.
        /// </summary>
        public static string Structure_DuplicateUniques {
            get {
                return ResourceManager.GetString("Structure_DuplicateUniques", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicate Unique-index found for &apos;{0}&apos;.\r\nStructureId: &apos;{1}&apos;;Name: &apos;{2}&apos;;Value: &apos;{3}&apos;;.
        /// </summary>
        public static string Structure_DuplicateUniques1 {
            get {
                return ResourceManager.GetString("Structure_DuplicateUniques1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not create StructureBuilder for Inserts and Id-type &apos;{0}&apos; for Schema &apos;{1}&apos;..
        /// </summary>
        public static string StructureBuilders_CreateForInsert {
            get {
                return ResourceManager.GetString("StructureBuilders_CreateForInsert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not compare StructureId&apos;s of different IdTypes..
        /// </summary>
        public static string StructureId_CompareTo_DifferentIdTypes {
            get {
                return ResourceManager.GetString("StructureId_CompareTo_DifferentIdTypes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not convert type &apos;{0}&apos; to a StructureId..
        /// </summary>
        public static string StructureId_ConvertFrom {
            get {
                return ResourceManager.GetString("StructureId_ConvertFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The sent string value &apos;{0}&apos; can not be converted to Id-type &apos;{1}&apos;..
        /// </summary>
        public static string StructureId_Create_FromString_WithSpecificId {
            get {
                return ResourceManager.GetString("StructureId_Create_FromString_WithSpecificId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value with type &apos;{0}&apos; can not be used to create a StructureId of type &apos;{1}&apos;..
        /// </summary>
        public static string StructureId_CreateByIdType {
            get {
                return ResourceManager.GetString("StructureId_CreateByIdType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type &apos;{0}&apos; is not supported for StructureId. Supported types are: Guid, Nullable-Guid, Int32, Nullable-Int32, Int64 and Nullable-Int64..
        /// </summary>
        public static string StructureId_InvalidType {
            get {
                return ResourceManager.GetString("StructureId_InvalidType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When using Guids the Id-property of the entity must be assigned before structure is created..
        /// </summary>
        public static string StructureIdFactory_MissingGuidValue {
            get {
                return ResourceManager.GetString("StructureIdFactory_MissingGuidValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When using Identities the Id-property of the entity must be assigned before structure is created..
        /// </summary>
        public static string StructureIdFactory_MissingIdentityValue {
            get {
                return ResourceManager.GetString("StructureIdFactory_MissingIdentityValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The identity type: &apos;{0}&apos; is not supported..
        /// </summary>
        public static string StructureIdFactory_UnSupportedIdentityType {
            get {
                return ResourceManager.GetString("StructureIdFactory_UnSupportedIdentityType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only strings and valuetypes can be stored as indexes..
        /// </summary>
        public static string StructureIndex_ValueArgument_IncorrectType {
            get {
                return ResourceManager.GetString("StructureIndex_ValueArgument_IncorrectType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only strings and valuetypes can be stored as indexes..
        /// </summary>
        public static string StructureIndex_ValueArgument_IncorrectType1 {
            get {
                return ResourceManager.GetString("StructureIndex_ValueArgument_IncorrectType1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Unique index &apos;{0}&apos;:&apos;{1}&apos; is evaluated to Null. This is not alowed..
        /// </summary>
        public static string StructureIndexesFactory_UniqueIndex_IsNull {
            get {
                return ResourceManager.GetString("StructureIndexesFactory_UniqueIndex_IsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Unique index &apos;{0}&apos;:&apos;{1}&apos; is evaluated to Null. This is not alowed..
        /// </summary>
        public static string StructureIndexesFactory_UniqueIndex_IsNull1 {
            get {
                return ResourceManager.GetString("StructureIndexesFactory_UniqueIndex_IsNull1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You cant apply Unique on a member that is not of a simple type e.g. (int, string, bool) etc..
        /// </summary>
        public static string StructureProperty_Ctor_UniqueOnNonSimpleType {
            get {
                return ResourceManager.GetString("StructureProperty_Ctor_UniqueOnNonSimpleType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property &apos;{0}&apos; is read-only..
        /// </summary>
        public static string StructureProperty_Setter_IsReadOnly {
            get {
                return ResourceManager.GetString("StructureProperty_Setter_IsReadOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not migrate structure set when Id type has changed..
        /// </summary>
        public static string StructureSetMigrator_MissmatchInIdTypes {
            get {
                return ResourceManager.GetString("StructureSetMigrator_MissmatchInIdTypes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not migrate structure set. No Id could be extracted from the new structure..
        /// </summary>
        public static string StructureSetMigrator_NewIdDoesNotExist {
            get {
                return ResourceManager.GetString("StructureSetMigrator_NewIdDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Id &apos;{0}&apos; of the new structure does not match the Id of the old structure &apos;{1}&apos;..
        /// </summary>
        public static string StructureSetMigrator_NewIdDoesNotMatchOldId {
            get {
                return ResourceManager.GetString("StructureSetMigrator_NewIdDoesNotMatchOldId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Id could be extracted from the old structure..
        /// </summary>
        public static string StructureSetMigrator_OldIdDoesNotExist {
            get {
                return ResourceManager.GetString("StructureSetMigrator_OldIdDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type of the Time stamp member &apos;{0}&apos; should be a Date..
        /// </summary>
        public static string TimeStampAccessor_Invalid_Type {
            get {
                return ResourceManager.GetString("TimeStampAccessor_Invalid_Type", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Time stamp member &apos;{0}&apos; must lie on the root object..
        /// </summary>
        public static string TimeStampAccessor_InvalidLevel {
            get {
                return ResourceManager.GetString("TimeStampAccessor_InvalidLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Supported generic collections on model are: implementations of either IEnumerable&lt;T&gt; or IList&lt;T&gt;..
        /// </summary>
        public static string TypeExtensions_ExtractGenericType {
            get {
                return ResourceManager.GetString("TypeExtensions_ExtractGenericType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The UniqueModes &apos;{0}&apos; is unknow and cant be mapped..
        /// </summary>
        public static string UniqueModesCantBeMapped {
            get {
                return ResourceManager.GetString("UniqueModesCantBeMapped", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The UniqueModes &apos;{0}&apos; is unknow and cant be mapped..
        /// </summary>
        public static string UniqueModesCantBeMapped1 {
            get {
                return ResourceManager.GetString("UniqueModesCantBeMapped1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You can&apos;t only access a member in a query expression unless it&apos;s a bool. You need to compare it against something..
        /// </summary>
        public static string WhereExpressionParser_NoMemberExpressions {
            get {
                return ResourceManager.GetString("WhereExpressionParser_NoMemberExpressions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The operator &apos;{0}&apos; is not supported for Qx-methods on enumerables..
        /// </summary>
        public static string WhereParser_QxEnumerables_OperatorNotSupported {
            get {
                return ResourceManager.GetString("WhereParser_QxEnumerables_OperatorNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no &apos;{0}&apos;-structure to update matching the sent Id &apos;{1}&apos;..
        /// </summary>
        public static string WriteSession_NoItemExistsForUpdate {
            get {
                return ResourceManager.GetString("WriteSession_NoItemExistsForUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Id &apos;{0}&apos; of the new structure does not match the Id of the old structure &apos;{1}&apos;..
        /// </summary>
        public static string WriteSession_UpdateMany_NewIdDoesNotMatchOldId {
            get {
                return ResourceManager.GetString("WriteSession_UpdateMany_NewIdDoesNotMatchOldId", resourceCulture);
            }
        }
    }
}
