# Member

    	TRuleTypeConjunction AreDeclaredIn(string pattern, bool useRegularExpressions = false);
        TRuleTypeConjunction AreDeclaredIn(IEnumerable<string> patterns, bool useRegularExpressions = false);
        TRuleTypeConjunction AreDeclaredIn(IType firstType, params IType[] moreTypes);
        TRuleTypeConjunction AreDeclaredIn(Type firstType, params Type[] moreTypes);
        TRuleTypeConjunction AreDeclaredIn(IObjectProvider<IType> types);
        TRuleTypeConjunction AreDeclaredIn(IEnumerable<IType> types);
        TRuleTypeConjunction AreDeclaredIn(IEnumerable<Type> types);

        //Negations


        TRuleTypeConjunction AreNotDeclaredIn(string pattern, bool useRegularExpressions = false);
        TRuleTypeConjunction AreNotDeclaredIn(IEnumerable<string> patterns, bool useRegularExpressions = false);
        TRuleTypeConjunction AreNotDeclaredIn(IType firstType, params IType[] moreTypes);
        TRuleTypeConjunction AreNotDeclaredIn(Type firstType, params Type[] moreTypes);
        TRuleTypeConjunction AreNotDeclaredIn(IObjectProvider<IType> types);
        TRuleTypeConjunction AreNotDeclaredIn(IEnumerable<IType> types);
        TRuleTypeConjunction AreNotDeclaredIn(IEnumerable<Type> types);
