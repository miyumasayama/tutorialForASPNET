﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using SelfAspNet.Models;

#pragma warning disable 219, 612, 618
#nullable disable

namespace SelfAspNet.CompiledModels
{
    internal partial class BookEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "SelfAspNet.Models.Book",
                typeof(Book),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(Book).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Book).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: 0);
            id.TypeMapping = IntTypeMapping.Default.Clone(
                comparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                keyComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v));
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var isbn = runtimeEntityType.AddProperty(
                "Isbn",
                typeof(string),
                propertyInfo: typeof(Book).GetProperty("Isbn", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Book).GetField("<Isbn>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            isbn.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(max)",
                    dbType: System.Data.DbType.String),
                storeTypePostfix: StoreTypePostfix.None);
            isbn.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var price = runtimeEntityType.AddProperty(
                "Price",
                typeof(int),
                propertyInfo: typeof(Book).GetProperty("Price", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Book).GetField("<Price>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0);
            price.TypeMapping = IntTypeMapping.Default.Clone(
                comparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                keyComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v));
            price.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var published = runtimeEntityType.AddProperty(
                "Published",
                typeof(DateTime),
                propertyInfo: typeof(Book).GetProperty("Published", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Book).GetField("<Published>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            published.TypeMapping = SqlServerDateTimeTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                keyComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                providerValueComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v));
            published.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var publisher = runtimeEntityType.AddProperty(
                "Publisher",
                typeof(string),
                propertyInfo: typeof(Book).GetProperty("Publisher", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Book).GetField("<Publisher>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            publisher.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(max)",
                    dbType: System.Data.DbType.String),
                storeTypePostfix: StoreTypePostfix.None);
            publisher.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var sample = runtimeEntityType.AddProperty(
                "Sample",
                typeof(bool),
                propertyInfo: typeof(Book).GetProperty("Sample", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Book).GetField("<Sample>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: false);
            sample.TypeMapping = SqlServerBoolTypeMapping.Default.Clone(
                comparer: new ValueComparer<bool>(
                    (bool v1, bool v2) => v1 == v2,
                    (bool v) => v.GetHashCode(),
                    (bool v) => v),
                keyComparer: new ValueComparer<bool>(
                    (bool v1, bool v2) => v1 == v2,
                    (bool v) => v.GetHashCode(),
                    (bool v) => v),
                providerValueComparer: new ValueComparer<bool>(
                    (bool v1, bool v2) => v1 == v2,
                    (bool v) => v.GetHashCode(),
                    (bool v) => v));
            sample.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var title = runtimeEntityType.AddProperty(
                "Title",
                typeof(string),
                propertyInfo: typeof(Book).GetProperty("Title", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Book).GetField("<Title>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            title.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(max)",
                    dbType: System.Data.DbType.String),
                storeTypePostfix: StoreTypePostfix.None);
            title.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static RuntimeSkipNavigation CreateSkipNavigation1(RuntimeEntityType declaringEntityType, RuntimeEntityType targetEntityType, RuntimeEntityType joinEntityType)
        {
            var skipNavigation = declaringEntityType.AddSkipNavigation(
                "Authors",
                targetEntityType,
                joinEntityType.FindForeignKey(
                    new[] { joinEntityType.FindProperty("BooksId") },
                    declaringEntityType.FindKey(new[] { declaringEntityType.FindProperty("Id") }),
                    declaringEntityType),
                true,
                false,
                typeof(ICollection<Author>),
                propertyInfo: typeof(Book).GetProperty("Authors", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Book).GetField("<Authors>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var inverse = targetEntityType.FindSkipNavigation("Books");
            if (inverse != null)
            {
                skipNavigation.Inverse = inverse;
                inverse.Inverse = skipNavigation;
            }

            return skipNavigation;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Books");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
