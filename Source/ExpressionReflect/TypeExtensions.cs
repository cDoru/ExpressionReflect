﻿namespace ExpressionReflect
{
	using System;
	using System.Linq;
	using System.Runtime.CompilerServices;

	internal static class TypeExtensions
	{
		internal static bool IsCompilerGenerated(this Type type)
		{
			bool isCompilerGenerated = type.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false).Any();
			return isCompilerGenerated;
		}

		internal static bool IsFunc(this Type type)
		{
			bool isFunc = false;

			if(type.IsGenericType)
			{
				Type definition = type.GetGenericTypeDefinition();
				isFunc = definition == typeof(Func<>) ||
					definition == typeof(Func<,>) ||
					definition == typeof(Func<,,>) ||
					definition == typeof(Func<,,,>) ||
					definition == typeof(Func<,,,,>);
			}

			return isFunc;
		}

		internal static bool IsAction(this Type type)
		{
			bool isAction = type == typeof(Action);

			if(type.IsGenericType)
			{
				Type definition = type.GetGenericTypeDefinition();

				isAction = isAction ||
					definition == typeof(Action<>) ||
					definition == typeof(Action<,>) ||
					definition == typeof(Action<,,>) ||
					definition == typeof(Action<,,,>);
			}

			return isAction;
		}

		internal static bool IsPredicate(this Type type)
		{
			bool isPredicate = false;

			if (type.IsGenericType)
			{
				Type definition = type.GetGenericTypeDefinition();
				isPredicate = definition == typeof(Predicate<>);
			}

			return isPredicate;
		}
	}
}